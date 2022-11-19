using Game.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class PlayerCollisionBehaviour : MonoBehaviour
    {

        private PlayerController _playerController;



        public void Initialize(PlayerController playerController)
        {
            _playerController= playerController;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("You LOST");
                _playerController.PlayerAnimationBehaviours.Animator.enabled = false;
                _playerController.GameManager.EventManager.LevelFailed();
                //düşma animasyonu 
                

                //bir event oluşturalım lost diye 
                // bu event çağırılınca enemyler ve chunklar durucak 
                //kamera değişimi
            }
        }


       




    }
}