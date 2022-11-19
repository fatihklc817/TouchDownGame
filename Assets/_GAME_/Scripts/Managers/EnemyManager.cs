using Game.Scripts.Behaviours;
using Game.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class EnemyManager : CustomBehaviour
    {
        [SerializeField] private List<GameObject> _enemyPrefabs;
        [SerializeField] private Transform _enemyParent;
        [SerializeField] private Transform _enemySpawnPoint;

        [SerializeField] private float _firstNumberOfEnemySpawnTimeRandomRange;
        [SerializeField] private float _secondNumberOfEnemySpawnTimeRandomRange;




        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
            GameManager.EventManager.OnStartPanelInput += SpawnEnemy;
        }

        


        private void SpawnEnemy()
        {
            StartCoroutine(SpawnEnemyCO());
        }


        IEnumerator SpawnEnemyCO()
        {
            var currentRandomIndex = Random.Range(0,_enemyPrefabs.Count);
            var currentEnemy = Instantiate(_enemyPrefabs[currentRandomIndex], _enemySpawnPoint.position, Quaternion.identity, _enemyParent);
            var currentEnemyMoveBehavior = currentEnemy.GetComponent<EnemyMovementBehaviour>();
            currentEnemyMoveBehavior.Initialize(this);
            yield return new WaitForSeconds(Random.Range(_firstNumberOfEnemySpawnTimeRandomRange, _secondNumberOfEnemySpawnTimeRandomRange));
            SpawnEnemy();
        }
    }
}
