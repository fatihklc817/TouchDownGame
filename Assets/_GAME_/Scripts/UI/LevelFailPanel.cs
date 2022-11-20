using Game.Scripts.Managers;
using Game.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.UI
{
    public class LevelFailPanel : UIPanel
    {
        public override void Initialize(UIManager uiManager)
        {
            base.Initialize(uiManager);
            UIManager.GameManager.EventManager.OnLevelFailed += ShowPanel;
        }

        private void OnDestroy()
        {
            UIManager.GameManager.EventManager.OnLevelFailed -= ShowPanel;
        }

        public void RetryButton()
        {
            SceneManager.LoadScene(0);
        }

        
    }
}