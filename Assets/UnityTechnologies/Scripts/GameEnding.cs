using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{

    //Public
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;

    //Private
    private bool isPlayerAtExit, isPlayerCaught;
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

            EndLevel(exitBackgroundImageCanvasGroup, false);

        }

        else if (isPlayerCaught)
        {


            EndLevel(caughtBackgroundImageCanvasGroup, true);

        }
    }

    /// <summary>
    ///    This method is called when the player is caught or reaches the exit 
    /// </summary>
    /// <param name="imageCanvasGroup"></param> Image Canvas Group

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart)
    {
        timer += Time.deltaTime;
        imageCanvasGroup.alpha = Math.Clamp(timer / fadeDuration, 0, 1);

        if (timer > fadeDuration + displayImageDuration)
        {

            if (doRestart)
            {
               SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Application.Quit();
            }
        }


    }
    
    public void CaughtPlayer()
    {
        isPlayerCaught = true;
    }
}
