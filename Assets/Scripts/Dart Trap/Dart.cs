
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dart : MonoBehaviour
{
    public Slider slider;
    public GameObject LoadingScreenS;
    public Rigidbody arrow;

    private void Update()
    {
        arrow.AddForce(Vector3.up * 2, ForceMode.Impulse);

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("Player"))
        {
            LoadSceneMain();
            Debug.Log("Hit");
        }

        if (col.transform.CompareTag("Wall"))
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
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
