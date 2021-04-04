using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private Coroutine loadingRoutine;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    
    public void GoToGame(){
        if (loadingRoutine == null)
            loadingRoutine = StartCoroutine(LoadGameScene(1.0f));
        Debug.Log("Play");
    }

    private IEnumerator LoadGameScene(float delayDuration)
    {
        yield return new WaitForSeconds(delayDuration);
        SceneManager.LoadScene("Testing");
    }

    public void Movements(){
        if (loadingRoutine == null)
            loadingRoutine = StartCoroutine(LoadMovementScene(0.5f));
        Debug.Log("Movements");
    }

    private IEnumerator LoadMovementScene(float delayDuration)
    {
        yield return new WaitForSeconds(delayDuration);
        SceneManager.LoadScene("MovementScene");
    }

    public void Creators(){
        if (loadingRoutine == null)
            loadingRoutine = StartCoroutine(LoadCreatorScene(0.5f));
        Debug.Log("Creators");
    }

    private IEnumerator LoadCreatorScene(float delayDuration)
    {
        yield return new WaitForSeconds(delayDuration);
        SceneManager.LoadScene("CreatorScene");
    }

    public void ExitGame(){
        Application.Quit ();
        Debug.Log("Quit");
    }
}
