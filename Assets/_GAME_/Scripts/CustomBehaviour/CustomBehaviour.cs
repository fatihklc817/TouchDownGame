using Game.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBehaviour : MonoBehaviour
{
    public GameManager GameManager { get; set; }


    public virtual void Initialize(GameManager gameManager)
    {
        GameManager = gameManager;
    }

}
