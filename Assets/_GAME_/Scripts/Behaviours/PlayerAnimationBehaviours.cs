using Game.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Behaviours {
    public class PlayerAnimationBehaviours : MonoBehaviour
    {

        

        public Animator Animator;

        private PlayerController _playerController;

        public void Initialize(PlayerController playerController)
        {
            _playerController= playerController;
        }


        public void TriggerRandomWinAnimation()
        {
            Animator.SetInteger("winIndex", Random.Range(0, 2));
            
            Animator.SetTrigger("win");
        }

    }
}