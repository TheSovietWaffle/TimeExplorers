using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

public class LevelSelecting : MonoBehaviour
{
    public int levelSelection;
    public Slider slider;
    public GameObject LoadingScreenS;
    public GameObject LevelScreenCanvas;

    private void Start() 
    {
        PauseMenuScript.isActiveMenu = true;
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape)) Exitting();
    }

    public void level1()
    {
        levelSelection = 3;
        LoadSceneMain();
    }
    public void level2()
    {
        levelSelection = 4;
        LoadSceneMain();
    }
    public void level3()
    {
        levelSelection = 5;
        LoadSceneMain();
    }
    public void level4()
    {
        levelSelection = 6;
        LoadSceneMain();
    }
    public void level5()
    {
        levelSelection = 7;
        LoadSceneMain();
    }
    public void level6()
    {
        levelSelection = 8;
        LoadSceneMain();
    }
    public void level7()
    {
        levelSelection = 9;
        LoadSceneMain();
    }
    public void level8()
    {
        levelSelection = 10;
        LoadSceneMain();
    }
    public void level9()
    {
        levelSelection = 11;
        LoadSceneMain();
    }
    public void level10()
    {
        levelSelection = 12;
        LoadSceneMain();
    }
    public void level11()
    {
        levelSelection = 13;
        LoadSceneMain();
    }
    public void level12()
    {
        levelSelection = 14;
        LoadSceneMain();
    }
    public void level13()
    {
        levelSelection = 15;
        LoadSceneMain();
    }
    public void level14()
    {
        levelSelection = 16;
        LoadSceneMain();
    }
    public void level15()
    {
        levelSelection = 17;
        LoadSceneMain();
    }
    public void level16()
    {
        levelSelection = 18;
        LoadSceneMain();
    }
    public void level17()
    {
        levelSelection = 19;
        LoadSceneMain();
    }
    public void level18()
    {
        levelSelection = 20;
        LoadSceneMain();
    }
    public void level19()
    {
        levelSelection = 21;
        LoadSceneMain();
    }
    public void level20()
    {
        levelSelection = 22;
        LoadSceneMain();
    }
    public void level21()
    {
        levelSelection = 23;
        LoadSceneMain();
    }
    

    public void LoadSceneMain()
    {

        StartCoroutine(LoadSceneAsync());
        Time.timeScale = 1f;
        
    }

    IEnumerator LoadSceneAsync()
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(levelSelection);

        LoadingScreenS.SetActive(true);
        

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progressValue;
            yield return null;
        }
        
    }

    async void  Exitting()
    {
        LevelScreenCanvas.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        await Task.Delay(4000);
        PauseMenuScript.isActiveMenu = false;
    }
}
