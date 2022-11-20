using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class EventManager : CustomBehaviour
    {
        public event Action OnStartGame;
        public event Action OnStartPanelInput;
        public event Action OnLevelFailed;
        public event Action OnLevelSucceed;
        public event Action OnEndChunkSpawned;
        public event Action OnPlayerStartedCollidingWithTeammate;
        public event Action OnPlayerStoppedCollidingWithTeammate;






        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
        }


        public void StartGame() 
        {
            OnStartGame?.Invoke();
        }

        public void StartPanelInput()
        {
            OnStartPanelInput?.Invoke();
        }

        public void LevelFailed()
        {
            OnLevelFailed?.Invoke();
        }

       public void LevelSucceed()
        {
            OnLevelSucceed?.Invoke();
        }


        public void EndChunkSpawned()
        {
            OnEndChunkSpawned?.Invoke();
        }

        public void PlayerStartedCollidingWithTeammate()
        {
            OnPlayerStartedCollidingWithTeammate?.Invoke();
        }

        public void PlayerStoppedCollidingWithTeammate()
        {
            OnPlayerStoppedCollidingWithTeammate?.Invoke();
        }





    }
}
