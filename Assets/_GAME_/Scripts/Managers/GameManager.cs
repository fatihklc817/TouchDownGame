using Game.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class GameManager : CustomBehaviour
    {
        public EventManager EventManager;
        public ChunkManager ChunkManager;
        public UIManager UIManager;
        public PlayerController PlayerController;

        private void Awake()
        {
            EventManager.Initialize(this);
            UIManager.Initialize(this);
            ChunkManager.Initialize(this);
            PlayerController.Initialize(this);
           
        }

        private void Start()
        {
            EventManager.StartGame();
        }

    }
}
