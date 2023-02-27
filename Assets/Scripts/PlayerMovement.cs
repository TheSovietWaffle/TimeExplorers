using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Sockets;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float slopeSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public float swingSpeed;
    public float climbSpeed;
    public float jumpSpeed;
    bool readyToJump;
    public float wallrunSpeed;


    [Header("KeyBinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public LayerMask whatIsSlope;
    
    public bool grounded;
    public bool sloped;
    public float hitHeight;
    RaycastHit distRay;
    public bool camShake;

    [Header("References")]
    public Climbing climbingScript;
    public TMPro.TextMeshProUGUI tracker;
    public Camera cam;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;
    public MovementState state;
    public enum MovementState
    {
        walking,
        sprinting,
        wallruning,
        air,
        swinging,
        climbing,
        sliding

    }

    public bool wallruning;
    public bool swinging;
    public bool climbing;
    public bool sliding;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
        sloped = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsSlope);

        //CameraEffects();
        MyInput();
        SpeedControl();

        if (grounded)
            rb.drag = groundDrag;
        else if (sloped)
            rb.drag = -60f;
        else
            rb.drag = 0f;
    }

    private void FixedUpdate()
    {

        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //when to jump
        if (Input.GetKey(jumpKey) && readyToJump && (grounded || sloped))
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {


        if (swinging) return;
        //calucate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        //on slope
        else if (sloped)
            rb.AddForce(moveDirection.normalized * slopeSpeed * 10f, ForceMode.Force);
        //in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void StateHandler()
    {
        if (wallruning)
        {
            state = MovementState.wallruning;
            moveSpeed = wallrunSpeed;
        }

        else if (swinging)
        {
            state = MovementState.swinging;
            moveSpeed = swingSpeed;
        }

        else if (climbing)
        {
            state = MovementState.climbing;
            moveSpeed = climbSpeed;
        }

    }

    public void CameraEffects()
    {
        Ray downRay = new Ray(transform.position, -Vector3.up);
        Physics.Raycast(downRay, out distRay);
        if (distRay.distance >= 50) camShake = true;
        tracker.text = distRay.distance.ToString();
        if (camShake == true && !grounded)
        {
            StartCoroutine(Shaker());
        }



    }

    IEnumerator Shaker()
    {
        yield return new WaitUntil(() => grounded == true);
        Transform oldCamPos = cam.transform;
        cam.DOShakePosition(0.3f,.1f);
        /*yield return new WaitForSecondsRealtime(.5f);
        cam.transform.position  = oldCamPos.transform.position;*/
        
    }


}
