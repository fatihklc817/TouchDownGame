using Game.Scripts.Managers;
using Game.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class UIManager : CustomBehaviour
    {

        [SerializeField] UIPanel _startPanel;
        [SerializeField] UIPanel _levelFailPanel;
        [SerializeField] UIPanel _levelSuccessPanel;

        private List<UIPanel> _uiPanels;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
            _uiPanels = new List<UIPanel> { _startPanel , _levelFailPanel, _levelSuccessPanel};
            for (int i = 0; i < _uiPanels.Count; i++)
            {
                _uiPanels[i].Initialize(this);
            }
        }


    }
}
