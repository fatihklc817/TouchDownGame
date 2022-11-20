using Cinemachine;
using Game.Scripts.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class PathManager : CustomBehaviour
    {
        public CinemachineSmoothPath ChunksPath { get; set; }
        public CinemachineSmoothPath EnemysPath { get; set; }
        public CinemachineSmoothPath TeammatesPath { get; set; }

        public Transform PathsParent => _pathsParent;

        public PathRotateBehaviour PathRotateBehaviour => _pathRotateBehaviour;

        [SerializeField] PathRotateBehaviour _pathRotateBehaviour;
        [SerializeField] CinemachineSmoothPath _chunksPath;
        [SerializeField] CinemachineSmoothPath _enemyPath;
        [SerializeField] CinemachineSmoothPath _teammatesPath;
        [SerializeField] Transform _pathsParent;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
            _pathRotateBehaviour.Initialize(this);
            ChunksPath = Instantiate(_chunksPath,_pathsParent);
            EnemysPath = Instantiate(_enemyPath,_pathsParent);
            TeammatesPath = Instantiate(_teammatesPath,_pathsParent);
        }

        


    }
}