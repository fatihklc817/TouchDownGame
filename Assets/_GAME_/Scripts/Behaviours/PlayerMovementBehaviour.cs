using Game.Scripts.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class PlayerMovementBehaviour : MonoBehaviour
    {
        public bool IsPlayerClicking { get; set; }

        [SerializeField] Transform _leftLanePosition;
        [SerializeField] float _playerHorizontalMoveSpeed = 2f;  
        [SerializeField] float _playerRunForwardSpeed = 10f; // after instantiating end chunk

        [SerializeField] Rigidbody _myRigidBody;
        [SerializeField] GameObject _myBones;
        private Collider[] _childColliders;               //for ragdoll
        private Rigidbody[] _childRigidBodies;

        private Vector3 _rightLanePosition;

        private PlayerController _playerController;
        private bool _isMouseButtonReleased = false;
        private bool _isInputActive = true;
        private bool _isEndChunkCalledOnce = false;

        public void Initialize(PlayerController playerController)
        {
            _playerController = playerController;
            _rightLanePosition = transform.position;

            _childColliders = _myBones.GetComponentsInChildren<Collider>();
            _childRigidBodies = _myBones.GetComponentsInChildren<Rigidbody>();
            CloseRagdollStart();


        }


        private void Update()
        {
            if (_isInputActive)
            {
                if (_playerController.GameManager.ChunkManager.IsEndChunkSpawned)  //if end chunk spawned players start running (normally does not chunks rotate)
                {
                    if (!_isEndChunkCalledOnce)
                    {
                    EndChunkSpawned();
                        _isEndChunkCalledOnce=true;
                    }
                    if (IsPlayerClicking)
                    {
                    transform.position += Vector3.forward * Time.deltaTime * _playerRunForwardSpeed *2 ;

                    }
                    else
                    {
                        transform.position += Vector3.forward * Time.deltaTime * _playerRunForwardSpeed;
                    }
                    
                }

                if (Input.GetMouseButton(0))   //go left with input
                {
                    IsPlayerClicking = true;
                    _isMouseButtonReleased = false;
                    if (transform.position.x >= _leftLanePosition.position.x)
                    {
                        transform.position += Vector3.left * _playerHorizontalMoveSpeed * Time.deltaTime;

                    }
                }

                if (_isMouseButtonReleased)  // go back to right 
                {
                    if (transform.position.x <= _rightLanePosition.x)
                    {
                        transform.position += Vector3.right * _playerHorizontalMoveSpeed * Time.deltaTime;
                    }
                }

                if (Input.GetMouseButtonUp(0))
                {

                    _isMouseButtonReleased = true;
                    IsPlayerClicking = false;

                }
            }
        }

        public void DisableInput()
        {
            _isInputActive= false;
            IsPlayerClicking = false;
        }

        private void EndChunkSpawned()  // when end chunk spawned do these... 
        {
           // _myBones.SetActive(false);
            _myRigidBody.useGravity = true;
            foreach (Collider col in _childColliders)
            {
                col.enabled = false;
               
            }

            foreach (Rigidbody rb in _childRigidBodies)
            {
                rb.isKinematic = true;
                
            }

            _myRigidBody.GetComponent<CapsuleCollider>().enabled = true;
        }


        public void OpenRagdollPhsyics() // open ragdoll physics
        {
             _myRigidBody.useGravity = false;
            foreach (Collider col in _childColliders)
            {
                col.enabled = true;
                
            }

            foreach (Rigidbody rb in _childRigidBodies)
            {
                rb.isKinematic = false;
                
            }

            _myRigidBody.GetComponent<CapsuleCollider>().enabled = false;
        }

        private void OnTriggerEnter(Collider other)   // when triggers with end do these...
        {
            if (other.CompareTag("end"))
            {
                _playerRunForwardSpeed = 0;
                _playerController.PlayerAnimationBehaviours.TriggerRandomWinAnimation();
                CallLevelSucceed();
                DisableInput();
                _playerController.GameManager.CameraManager.ChangeToEndCamera();
               
            }
            
        }
        private void CloseRagdollStart()  // close ragdoll at start 
        {
            _myRigidBody.useGravity = false;
            foreach (Collider col in _childColliders)
            {
                col.enabled = false;

            }

            foreach (Rigidbody rb in _childRigidBodies)
            {
                rb.isKinematic = true;

            }
        }

        private void CallLevelSucceed()
        {
            StartCoroutine(LevelSucceedCo());
        }

        IEnumerator LevelSucceedCo() 
        {
            yield return new WaitForSeconds(2);
            _playerController.GameManager.EventManager.LevelSucceed();
        }

    }
}
