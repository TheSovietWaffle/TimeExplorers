using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject LoadingScreenS;
    public GameObject PastScene;
    public Slider slider;


    public void QuitGame()
    {
        
        Application.Quit();
    }

   

    public void LoadScene()
    {

        StartCoroutine(LoadSceneAsync());
    }
    IEnumerator LoadSceneAsync()
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        LoadingScreenS.SetActive(true);
        PastScene.SetActive(false);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progressValue;
            yield return null;
        }
    }
}
