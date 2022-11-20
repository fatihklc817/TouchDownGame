using Game.Scripts.Behaviours;
using Game.Scripts.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Scripts.Managers
{
    public class ChunkManager : CustomBehaviour
    {
        public bool IsEndChunkSpawned  = false;


        [SerializeField] GameObject _chunkPrefab;
        [SerializeField] Transform _chunksParent;
        [SerializeField] Transform _chunksSpawnPoint;

        [SerializeField] GameObject _endPrefab;
        [SerializeField] Transform _endSpawnPoint;


        

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
            LocalStart();
        }


        private void LocalStart()
        {
            InstantiateStartingChunks();                                                                                                        
            var firstChunk =Instantiate(_chunkPrefab, _chunksSpawnPoint.position, Quaternion.identity, _chunksParent);
            firstChunk.GetComponent<ChunkRotatingBehaviour>().Initialize(this);
        }

        public void SpawnTheENDChunk()
        {
            
            Instantiate(_endPrefab, _endSpawnPoint.position, Quaternion.Euler(12f,0f,0f), _endSpawnPoint);
            GameManager.EventManager.EndChunkSpawned();
            GameManager.EnemyManager.IsAbleToSpawn= false;
            IsEndChunkSpawned=true;
            //pathler duracak
            //playerlar ve teammateler koşmaya başlayacak
            //enemyspawn durabilir

            GameManager.PathManager.PathRotateBehaviour.RotatePaths();
            
        }


        private void InstantiateStartingChunks()
        {
            for (int i = 10; i < 71; i+=10)
            {

            var currentChunk1 = Instantiate(_chunkPrefab, _chunksSpawnPoint.position, Quaternion.identity, _chunksParent);
            var currentChunkRotationBehaviour = currentChunk1.GetComponent<ChunkRotatingBehaviour>();
                currentChunkRotationBehaviour.Initialize(this);
                currentChunkRotationBehaviour.GetThePosition(i);
                currentChunkRotationBehaviour.IsChunkInitial = true;
            }   
        }


        public void SpawnChunk()
        {
            var currentChunk = Instantiate(_chunkPrefab, _chunksSpawnPoint.position, Quaternion.identity, _chunksParent);
            var currentChunkRotatingBehaviour = currentChunk.GetComponent<ChunkRotatingBehaviour>();
            currentChunkRotatingBehaviour.Initialize(this);
            currentChunkRotatingBehaviour.MakeChunkAbleToMove();

          
        }

        
    }
}