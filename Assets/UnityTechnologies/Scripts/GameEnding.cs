using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{   
    
    public float fadeDuration = 1f;

    private bool isPlayerAtExit;
    public GameObject player;

    private void OnTriggerEnter(Collider other) //El other hace referencia al otro objecto de la colision
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;
        }
    }


    private void Update()
    {
        if (isPlayerAtExit)
        {
           // EndGame();
        }
    }
}
