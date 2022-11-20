using Game.Scripts.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class TeammateManager : CustomBehaviour
    {
        public bool IsTeammatesStopping = false;
        public int PassedTeammateNumber = 0 ;

        [SerializeField] private List<GameObject> _teammatePrefabs;
        [SerializeField] private Transform _teammatesParent;
        [SerializeField] private Transform _teammateSpawnPoint;

        [SerializeField] private int _teammateNumberToCompleteLevel;

        [SerializeField] private float _firstNumberOfEnemySpawnTimeRandomRange;
        [SerializeField] private float _secondNumberOfEnemySpawnTimeRandomRange;

        private bool _isAbleToSpawn = true;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
            GameManager.EventManager.OnStartPanelInput += SpawnTeammate;
        }

        private void OnDestroy()
        {
            GameManager.EventManager.OnStartPanelInput -= SpawnTeammate;
        }

        public void SpawnTeammate()
        {
            if (_isAbleToSpawn)
            {

            StartCoroutine(SpawnTeammateCO());
            }

            
        }

        IEnumerator SpawnTeammateCO()
        {
            if (PassedTeammateNumber < _teammateNumberToCompleteLevel)
            {
                if (!IsTeammatesStopping)
                {
                var currentRandomIndex = Random.Range(0,_teammatePrefabs.Count);
                var currentTeammate = Instantiate(_teammatePrefabs[currentRandomIndex],_teammateSpawnPoint.position,Quaternion.identity,_teammatesParent);
                currentTeammate.GetComponent<TeammateMoveBehaviour>().Initialize(this);

                }

            }
            else if(PassedTeammateNumber >= _teammateNumberToCompleteLevel) 
            {
                GameManager.ChunkManager.SpawnTheENDChunk();
                _isAbleToSpawn = false;
            }

            yield return new WaitForSeconds(Random.Range(_firstNumberOfEnemySpawnTimeRandomRange, _secondNumberOfEnemySpawnTimeRandomRange));
            SpawnTeammate();
        }


    }
}