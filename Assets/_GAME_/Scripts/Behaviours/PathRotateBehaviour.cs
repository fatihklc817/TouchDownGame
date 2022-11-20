using Game.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Behaviours {
    public class PathRotateBehaviour : MonoBehaviour
    {

        [SerializeField] Transform _pivotPoint;

        private bool _isRotationStarted;

        private PathManager _pathManager;

        public void Initialize(PathManager pathManager)
        {
            _pathManager= pathManager;
        }

        private void Update()
        {
            if (_isRotationStarted)
            {
                if (_pathManager.PathsParent.transform.up.y > 0.98f)
                {
                    
                    _pathManager.PathsParent.transform.RotateAround(_pivotPoint.position, Vector3.left, 3 * Time.deltaTime);

                }

            }
        }
        public void RotatePaths()
        {
           _isRotationStarted= true;

        }

       



    }
}
