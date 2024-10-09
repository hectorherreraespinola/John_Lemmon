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
    public AudioSource exitAudio, caughtAudio;
    
    
    //Private
    private bool isPlayerAtExit;
    private bool isPlayerCaught;
    private float timer;
    private bool hasAudioPlayed;


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

            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);

        }

        else if (isPlayerCaught)
        {


            EndLevel(caughtBackgroundImageCanvasGroup, true,caughtAudio);

        }
    }

    /// <summary>
    ///    This method is called when the player is caught or reaches the exit 
    /// </summary>
    /// <param name="imageCanvasGroup"></param> Image Canvas Group

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {   
        if(!hasAudioPlayed)
        {
            audioSource.Play();
            hasAudioPlayed = true;
        }
        
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
