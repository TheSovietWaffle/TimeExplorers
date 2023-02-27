using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;
    public GameObject LoadingScreenS;
    
    
   
    public void SetVolume(float volume)
    {
       audioMixer.SetFloat("volume", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        
    }

    
    public void ResetPrefs()
    {
        PlayerPrefs.SetInt("LevelsCompleted", 0);
        PlayerPrefs.SetString("RedAnkhState", "NotPickedUp");
        PlayerPrefs.SetString("GreenAnkhState", "NotPickedUp");
        PlayerPrefs.SetString("BlueAnkhState", "NotPickedUp");
        LoadSceneMain();
    }
    
    public void LoadSceneMain()
    {

        StartCoroutine(LoadSceneAsync());
        Time.timeScale = 1f;
        
    }

    IEnumerator LoadSceneAsync()
    {   
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        
        LoadingScreenS.SetActive(true);
        

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progressValue;
            yield return null;
        }
        
    }
}
