﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (gameIsPaused){
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void GoToMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Return to Menu");
    }

    public void ExitGame(){
        Application.Quit ();
        Debug.Log("Quit");
    }

    public void Restart(){
        Debug.Log("Reloading scene");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Testing");
    }
}
