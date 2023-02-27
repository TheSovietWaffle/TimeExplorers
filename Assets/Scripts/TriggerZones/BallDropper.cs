using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BallDropper : MonoBehaviour
{

    public GameObject slider1;
    public GameObject slider2;
    public Animation anim;
    public Animation anim2;

    private bool played;

    void OnTriggerEnter(Collider other)
    {
        PlayAnimation();
    }

    private void PlayAnimation()
    {
        if (!played)
        {
            slider1.GetComponent<Animation>().PlayQueued("SlidingDoorBall");
            slider2.GetComponent<Animation>().PlayQueued("SlidingDoorBall2");
            played = true;
        }

    }
}
