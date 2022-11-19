using Game.Scripts.Managers;
using Game.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.UI
{
    public class LevelSuccessPanel : UIPanel
    {
        public override void Initialize(UIManager uiManager)
        {
            base.Initialize(uiManager);
            UIManager.GameManager.EventManager.OnLevelSucceed += ShowPanel;
        }

        private void OnDestroy()
        {
            UIManager.GameManager.EventManager.OnLevelSucceed -= ShowPanel;
        }


        public void RestartButton()
        {
            SceneManager.LoadScene(0);
        }
    }
}
