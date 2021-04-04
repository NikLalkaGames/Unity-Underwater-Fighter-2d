using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    public GameObject gameOverMenuUI;

    // Update is called once per frame
    void FixUpdate()
    {
        /* Короче, здесь наверное надо вставить условие включения GameOverMenu
        
        if (хп_нашего_Булча < 0){
            gameOverMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        */
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
