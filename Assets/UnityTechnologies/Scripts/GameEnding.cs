using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{   
    
    //Public
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    
    //Private
    private bool isPlayerAtExit;
    private float timer;
   
    
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
           timer += Time.deltaTime;
           exitBackgroundImageCanvasGroup.alpha = Math.Clamp(timer / fadeDuration, 0, 1);
           
           if (timer > fadeDuration + displayImageDuration)
           {
               EndLevel();
           }
        }
    }

    void EndLevel()
    {
        Application.Quit();
    }
}
