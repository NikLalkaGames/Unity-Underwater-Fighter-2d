using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenuScript : MonoBehaviour
{

    private Coroutine loadingRoutine;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void GoToMenu(){
        if (loadingRoutine == null)
            loadingRoutine = StartCoroutine(LoadMenuScene(0.5f));
        Debug.Log("Return to Menu");
    }

    private IEnumerator LoadMenuScene(float delayDuration)
    {
        yield return new WaitForSeconds(delayDuration);
        SceneManager.LoadScene("MainMenu");
    }
}
