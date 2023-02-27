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
    public Canvas pauCanv;  
    public int a;
    public int b;
    public int c;  

    private void Start()
    {
        
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
             Exitting();
             StartCoroutine(Pauser());
        }
        
    }

    public void level1()
    {
        if (PlayerPrefs.GetInt("LevelsCompleted") >= a-3)
        {
            levelSelection = a;
            LoadSceneMain();
        }
    }
    public void level2()
    {
        if (PlayerPrefs.GetInt("LevelsCompleted") >= b-3)
        {
            levelSelection = b;
            LoadSceneMain();
        }
    }

    public void level3()
    {
        if (PlayerPrefs.GetInt("LevelsCompleted") >= c-3)
        {
            levelSelection = c;
            LoadSceneMain();
        }
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

    async void Exitting()
    {
        LevelScreenCanvas.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        await Task.Delay(4000);
        PauseMenuScript.isActiveMenu = false;
    }

    IEnumerator Pauser()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        pauCanv.gameObject.SetActive(true);
    }
}
