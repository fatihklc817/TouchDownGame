using Cinemachine;
using Game.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class EnemyMovementBehaviour : MonoBehaviour
    {
        [SerializeField] private CinemachineSmoothPath _path;
        [SerializeField] private float _enemySpeed;
        [SerializeField] private float _enemyBoostedSpeed;

        private float _enemyStartingSpeedCache;
        private float _enemyPositionOnPath;

        private EnemyManager _enemyManager;
        

        public void Initialize(EnemyManager enemyManager)
        {
            _enemyManager = enemyManager;
            _enemyStartingSpeedCache = _enemySpeed;           
        
        }



        private void Update()
        {
            if (_enemyManager.GameManager.PlayerController.PlayerMovementBehaviour.IsPlayerClicking)
            {
                _enemySpeed = _enemyBoostedSpeed;
            }
            else
            {
                _enemySpeed = _enemyStartingSpeedCache;
            }


            transform.position = _path.EvaluatePositionAtUnit(_enemyPositionOnPath, CinemachinePathBase.PositionUnits.Distance);
            transform.rotation = _path.EvaluateOrientationAtUnit(_enemyPositionOnPath, CinemachinePathBase.PositionUnits.Distance);
            
            
            
            _enemyPositionOnPath += _enemySpeed * Time.deltaTime;
            

            if (_enemyPositionOnPath > _path.PathLength)
            {
                Destroy(gameObject);
            }
        }


    }
}



