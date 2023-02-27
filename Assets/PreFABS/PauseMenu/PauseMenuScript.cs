using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenuScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject LoadingScreenS;
    public GameObject PastScene;
    public Slider slider;
    public static bool isActiveMenu = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isActiveMenu == false)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
                
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;       
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void QuitGame()
    {
        
        Application.Quit();
    }
    public void LoadSceneNext()
    {

        StartCoroutine(LoadSceneAsyncNext());
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    IEnumerator LoadSceneAsyncNext()
    {

        AsyncOperation operationn = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        LoadingScreenS.SetActive(true);
        PastScene.SetActive(false);

        while (!operationn.isDone)
        {
            float progressValue = Mathf.Clamp01(operationn.progress / 0.9f);
            slider.value = progressValue;
            yield return null;
        }
        
    }
    public void LoadSceneMain()
    {

        StartCoroutine(LoadSceneAsync());
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    IEnumerator LoadSceneAsync()
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(0);

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
    