using Game.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class UIPanel : CustomBehaviour
    {
        public UIManager UIManager { get; set; }

        public virtual void Initialize(UIManager uiManager)
        {
            UIManager= uiManager;
            GameManager = UIManager.GameManager;

        }

        public virtual void ShowPanel()
        {
            gameObject.SetActive(true);
        }

        public virtual void HidePanel()    
        {
            gameObject.SetActive(false);
        }

    }
}