using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedo : MonoBehaviour
{
    public TMPro.TextMeshProUGUI speedo;
    
    public Rigidbody rb;
    
    public PlayerMovement pm;

    public TMPro.TextMeshProUGUI tracker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedo.text = Mathf.Round(rb.velocity.magnitude).ToString();
        
    }
}
