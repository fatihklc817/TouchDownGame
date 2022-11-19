using Game.Scripts.Managers;
using Game.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Scripts.UI
{
    public class StartPanel : UIPanel, IPointerDownHandler
    {
        public override void Initialize(UIManager uiManager)
        {
            base.Initialize(uiManager);
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            base.HidePanel();
            GameManager.EventManager.StartPanelInput();
        }
    }
}