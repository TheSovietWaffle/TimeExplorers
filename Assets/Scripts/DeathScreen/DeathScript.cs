using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScript : MonoBehaviour
{
    public Slider slider;
    public GameObject LoadingScreenS;
    public GameObject LevelScreenCanvas;

    
    void OnTriggerEnter(Collider other) 
    {
        if(other.transform.CompareTag("Player")) LoadSceneMain();
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
