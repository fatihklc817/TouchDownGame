using Game.Scripts.Behaviours;
using Game.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public class PlayerController : CustomBehaviour
    {
        [SerializeField] PlayerMovementBehaviour _playerMovementBehaviour;
        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
            _playerMovementBehaviour.Initialize(this);
        }
    }
}
