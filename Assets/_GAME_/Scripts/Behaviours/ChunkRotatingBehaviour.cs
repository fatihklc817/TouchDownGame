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

        [SerializeField] private CinemachineSmoothPath _path;
        [SerializeField] private bool _isAbleToMove = false;
        [SerializeField] private float _chunkRotationSpeed = 10f;
        
        private float _positionOnPath = 0f;
        private ChunkManager _chunkManager;
        

        public void Initialize(ChunkManager chunkManager)
        {
            _chunkManager = chunkManager;
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
            transform.position = _path.EvaluatePositionAtUnit(_positionOnPath, CinemachinePathBase.PositionUnits.Distance);
            transform.rotation = _path.EvaluateOrientationAtUnit(_positionOnPath, CinemachinePathBase.PositionUnits.Distance);

            if (_isAbleToMove)
            {
                _positionOnPath += _chunkRotationSpeed * Time.deltaTime;

            }

            if (_positionOnPath > _path.PathLength)
            {
                Destroy(gameObject);
            }
        }


    }
}