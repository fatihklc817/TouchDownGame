using Game.Scripts.Managers;
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

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
            callSpawnCorotuine();
        }

        private void Update()
        {
            
        }


        private void callSpawnCorotuine()
        {
            StartCoroutine(SpawnChunkCo());
        }

        IEnumerator SpawnChunkCo()
        {
            Instantiate(ChunkPrefab,chunksSpawnPoint.position,Quaternion.identity,chunksParent);
            yield return new WaitForSeconds(1f);
            callSpawnCorotuine();
            
        }
    }
}