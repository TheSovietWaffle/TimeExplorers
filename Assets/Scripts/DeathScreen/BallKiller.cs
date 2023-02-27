using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallKiller : MonoBehaviour
{
    public Slider slider;
    public GameObject LoadingScreenS;
    public GameObject LevelScreenCanvas;
    public Collider player;
    public GameObject obs1;
    public Rigidbody balls;

    private float ballSpeesMax;
    private float ballSpeedCur;



    void OnTriggerEnter(Collider col)
    {
        /*
        if (col.transform.CompareTag("Obstacle"))
        {
            
            Destroy(obs1);
            StartCoroutine(Boosting());
            
            
            
            
        }*/
    }

    IEnumerator Boosting()
    {
        yield return new WaitForSecondsRealtime(1f);
        balls.AddForce(Vector3.up * 10, ForceMode.Force);
        Debug.Log("Boosted");
    }
    void Update()
    {
        foreach (Collider c in Physics.OverlapSphere(transform.position, 3f))
        {
            if (c.CompareTag("Obstacle")) Destroy(c.gameObject);
            if (c.CompareTag("Player")) LoadSceneMain();
            
        }
    }
    public void MomentumCons()
    {
        if (balls.velocity.magnitude > ballSpeesMax)
            ballSpeesMax = balls.velocity.magnitude;
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
