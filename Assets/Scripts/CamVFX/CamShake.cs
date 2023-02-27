using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CamShake : MonoBehaviour
{
    [Header("Refferences")]
    public PlayerMovement pm;
    public PlayerCam pc;

    [Header("Variables")]
    public float shakeDuration=1;
    public float shakeMagnitude=1;

    // Update is called once per frame
    void Update()
    {   
        if(pm.swinging)GetComponent<Camera>().DOShakePosition(shakeDuration,0.2f,1);
            
            
        
        
    }
}
