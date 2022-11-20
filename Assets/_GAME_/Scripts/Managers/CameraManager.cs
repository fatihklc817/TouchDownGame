using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class CameraManager : CustomBehaviour
    {

        [SerializeField] GameObject _mainCamera;
        [SerializeField] GameObject _boostCamera;
        [SerializeField] GameObject _winCamera;

        private bool _isEndCameraActive = false;
        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
        }

        private void Update()
        {
            if (!_isEndCameraActive) 
            {

                if (GameManager.PlayerController.PlayerMovementBehaviour.IsPlayerClicking)
                {
                    if (!_boostCamera.activeInHierarchy)
                    {
                        _boostCamera.SetActive(true);
                        _mainCamera.SetActive(false);    

                    }
                }
                else
                {
                    if (_boostCamera.activeInHierarchy)
                    {
                        _boostCamera.SetActive(false);
                        _mainCamera.SetActive(true);
                    }
                }
            }

        }


        public void ChangeToEndCamera()
        {
            _boostCamera.SetActive(false);
            _mainCamera.SetActive(false);
            _winCamera.SetActive(true);
            _isEndCameraActive= true;
            
        }
    }
}