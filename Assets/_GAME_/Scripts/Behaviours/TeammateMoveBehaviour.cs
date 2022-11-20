using Cinemachine;
using Game.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Game.Scripts.Behaviours
{
    public class TeammateMoveBehaviour : MonoBehaviour
    {
        [SerializeField] float _teammateSpeed;
        [SerializeField] float _teammateBoostedSpeed;

        private float _teammateStartingSpeedCache;
        private float _teammatePositionOnPath = 90f;  // teammates run on path backwards so their run animation could be reversed

        private bool _isAbleToMove=true;

        private CinemachineSmoothPath _path;

        private TeammateManager _teammateManager;
        private bool _isTeammatesOnPath = true;

        public void Initialize(TeammateManager teammateManager)
        {
            _teammateManager = teammateManager;
            _teammateStartingSpeedCache = _teammateSpeed;
            _path = _teammateManager.GameManager.PathManager.TeammatesPath;
            
            _teammatePositionOnPath = _path.PathLength;
                

            _teammateManager.GameManager.EventManager.OnPlayerStartedCollidingWithTeammate += DisableMovement;
            _teammateManager.GameManager.EventManager.OnPlayerStoppedCollidingWithTeammate += ActivateMovement;
            _teammateManager.GameManager.EventManager.OnEndChunkSpawned += LeaveThePath;
        }

        private void OnDestroy()
        {
            _teammateManager.GameManager.EventManager.OnPlayerStartedCollidingWithTeammate -= DisableMovement;
            _teammateManager.GameManager.EventManager.OnPlayerStoppedCollidingWithTeammate -= ActivateMovement;
            _teammateManager.GameManager.EventManager.OnEndChunkSpawned -= LeaveThePath;
        }

        private void Update()  
        {
            if (_teammateManager.GameManager.PlayerController.PlayerMovementBehaviour.IsPlayerClicking)
            {
                _teammateSpeed = _teammateBoostedSpeed;
            }
            else
            {
                _teammateSpeed = _teammateStartingSpeedCache;
            }

            if (_isTeammatesOnPath)  //if end chunk is not spawned they are on the path and they go on the path
            {
            transform.position = _path.EvaluatePositionAtUnit(_teammatePositionOnPath, CinemachinePathBase.PositionUnits.Distance);
            transform.rotation = _path.EvaluateOrientationAtUnit(_teammatePositionOnPath, CinemachinePathBase.PositionUnits.Distance);

            }
            else if (!_isTeammatesOnPath)   // after spawn of end chunk teammates leaves the path and runs forward
            {
                transform.position += Vector3.forward * Time.deltaTime * _teammateSpeed;
            }

            if (_isAbleToMove && _isTeammatesOnPath)  // go on path backwards
            {
                _teammatePositionOnPath -= _teammateSpeed * Time.deltaTime;
            }

            if (_teammatePositionOnPath < 1)    // destroy when the path over and increase passedTeammateNumber to finish game.
            {
                _teammateManager.PassedTeammateNumber += 1;
                Destroy(gameObject);
            }
        }

        private void DisableMovement()
        {
            _isAbleToMove = false;
        }

        private void ActivateMovement()
        {
            _isAbleToMove = true;
        }

        private void LeaveThePath()
        {
            _isTeammatesOnPath= false;
        }


        private void OnTriggerEnter(Collider other)       // stop when trigger with player.
        {
            _teammateManager.IsTeammatesStopping = true;
            _teammateManager.GameManager.EventManager.PlayerStartedCollidingWithTeammate();
        }

        private void OnTriggerExit(Collider other)
        {
            _teammateManager.IsTeammatesStopping = false;
            _teammateManager.GameManager.EventManager.PlayerStoppedCollidingWithTeammate();
        }

    }
}