using Game.Scripts.Behaviours;
using Game.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public class PlayerController : CustomBehaviour
    {
        public PlayerMovementBehaviour PlayerMovementBehaviour => _playerMovementBehaviour;
        public PlayerCollisionBehaviour PlayerCollisionBehaviour => _playerCollisionBehaviour;  
        public PlayerAnimationBehaviours PlayerAnimationBehaviours => _playerAnimationBehaviours;

        [SerializeField] PlayerMovementBehaviour _playerMovementBehaviour;
        [SerializeField] PlayerCollisionBehaviour _playerCollisionBehaviour;
        [SerializeField] PlayerAnimationBehaviours _playerAnimationBehaviours;


        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
            _playerMovementBehaviour.Initialize(this);
            _playerCollisionBehaviour.Initialize(this);
            _playerAnimationBehaviours.Initialize(this);
        }
    }
}
