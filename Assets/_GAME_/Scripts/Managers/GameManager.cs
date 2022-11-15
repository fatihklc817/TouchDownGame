using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class GameManager : CustomBehaviour
    {
        public ChunkManager ChunkManager;

        private void Awake()
        {
            ChunkManager.Initialize(this);
        }


    }
}
