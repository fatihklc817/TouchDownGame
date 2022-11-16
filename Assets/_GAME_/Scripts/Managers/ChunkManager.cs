using Game.Scripts.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class ChunkManager : CustomBehaviour
    {
        [SerializeField] GameObject ChunkPrefab;
        [SerializeField] Transform chunksParent;
        [SerializeField] Transform chunksSpawnPoint;

        private float _timeDelayToSpawnChunks;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
            LocalStart();
            callSpawnCorotuine();
        }

        private void LocalStart()
        {
            _timeDelayToSpawnChunks = 1 / (ChunkPrefab.GetComponent<ChunkRotatingBehaviour>().ChunkRotationSpeed / 10f); //this calculates what must be the spawntime.
            InstantiateStartingChunks();                                                                                                           //to make it seem as if it were combined

        }

        private void InstantiateStartingChunks()
        {
            for (int i = 10; i < 71; i+=10)
            {

            var currentChunk1 = Instantiate(ChunkPrefab, chunksSpawnPoint.position, Quaternion.identity, chunksParent);
            currentChunk1.GetComponent<ChunkRotatingBehaviour>().GetThePosition(i);
            }

           
        }

        private void callSpawnCorotuine()  
        {
            StartCoroutine(SpawnChunkCo());
        }

        IEnumerator SpawnChunkCo()        //spawsn Chunks 
        {
            var currentChunk = Instantiate(ChunkPrefab,chunksSpawnPoint.position,Quaternion.identity,chunksParent);
            yield return new WaitForSeconds(_timeDelayToSpawnChunks);  
                                                  
            callSpawnCorotuine();
            
        }
    }
}