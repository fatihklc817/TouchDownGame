using Game.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class PlayerMovementBehaviour : MonoBehaviour
    {

        [SerializeField] Transform _leftLanePosition;
        [SerializeField] float _playerHorizontalMoveSpeed = 2f;

        private Vector3 _rightLanePosition;

        private PlayerController _playerController;
        private bool _isMouseButtonReleased = false;

        public void Initialize(PlayerController playerController)
        {
            _playerController = playerController;
            _rightLanePosition = transform.position;
        }


        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                _isMouseButtonReleased = false;
                if (transform.position.x >= _leftLanePosition.position.x)
                {
                transform.position += Vector3.left * _playerHorizontalMoveSpeed * Time.deltaTime;

                }
            }

            if (_isMouseButtonReleased)
            {
                if (transform.position.x <= _rightLanePosition.x)
                {
                    transform.position += Vector3.right * _playerHorizontalMoveSpeed * Time.deltaTime;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("bıraktım");
                _isMouseButtonReleased = true;
               
            }

        }

    }
}
