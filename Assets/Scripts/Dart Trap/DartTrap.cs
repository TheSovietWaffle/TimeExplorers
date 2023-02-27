using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartTrap : MonoBehaviour
{
    public GameObject dart;
    public Vector3 pos1, pos2, pos3, pos4, pos5, pos6, pos7, pos8, pos9;
    public Quaternion quat;
    void Start()
    {
        Debug.Log("Starting");
        StartCoroutine(DartFire());
    }


    IEnumerator DartFire()
    {
        do
        {
            Debug.Log("Shoot");
            Instantiate(dart, pos1, quat);
            Instantiate(dart, pos2, quat);
            Instantiate(dart, pos3, quat);  
            Instantiate(dart, pos4, quat);
            Instantiate(dart, pos5, quat);
            Instantiate(dart, pos6, quat);
            Instantiate(dart, pos7, quat);
            Instantiate(dart, pos8, quat);
            Instantiate(dart, pos9, quat);
            yield return new WaitForSecondsRealtime(2f);
        } while (true);
    }
}
