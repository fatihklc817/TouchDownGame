using Cinemachine;
using Game.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class ChunkRotatingBehaviour : MonoBehaviour
    {
        public float ChunkRotationSpeed => _chunkRotationSpeed;
        public float ChunkBoostedRotationSpeed => _chunkBoostedRotationSpeed;
 
        public bool IsChunkInitial { get; set; }


        [SerializeField] private CinemachineSmoothPath _path;
        [SerializeField] private float _chunkRotationSpeed = 10f;
        [SerializeField] private float _chunkBoostedRotationSpeed = 20f;
       
         private bool _isAbleToMove = false;
        private float _chunkStartingRotatingSpeedCache;
        private float _positionOnPath = 0f;
        private bool _didChunkPastSpawnLimitPosition = false;

        private ChunkManager _chunkManager;
        

        public void Initialize(ChunkManager chunkManager)
        {
            _chunkManager = chunkManager;
            _chunkStartingRotatingSpeedCache = _chunkRotationSpeed;

            _chunkManager.GameManager.EventManager.OnStartPanelInput += MakeChunkAbleToMove;
           

        }

        private void OnDestroy()
        {
            _chunkManager.GameManager.EventManager.OnStartPanelInput-= MakeChunkAbleToMove;
           
        }

        public void GetThePosition(float posOnPath)
        {
            _positionOnPath = posOnPath;
        }

        public void MakeChunkAbleToMove()
        {
            _isAbleToMove=true;
        }

      


        private void Update()
        {   
            if (_chunkManager.GameManager.PlayerController.PlayerMovementBehaviour.IsPlayerClicking) 
            {
                _chunkRotationSpeed = _chunkBoostedRotationSpeed;
            }
            else
            {
                _chunkRotationSpeed = _chunkStartingRotatingSpeedCache;
            }

            transform.position = _path.EvaluatePositionAtUnit(_positionOnPath, CinemachinePathBase.PositionUnits.Distance);
            transform.rotation = _path.EvaluateOrientationAtUnit(_positionOnPath, CinemachinePathBase.PositionUnits.Distance);

            if (_isAbleToMove)
            {
                _positionOnPath += _chunkRotationSpeed * Time.deltaTime;

            }

            if (!_didChunkPastSpawnLimitPosition)
            {
                if (_positionOnPath > 10f && !IsChunkInitial)
                {
                    _chunkManager.SpawnChunk();
                    _didChunkPastSpawnLimitPosition = true;
                }
            }

            if (_positionOnPath > _path.PathLength)
            {
                Destroy(gameObject);
            }
        }


    }
}