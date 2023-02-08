using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{

    
    [Header("Refferences")]
    public Transform orientation;
    public Rigidbody rb;
    public LayerMask whatIsWall;
    public PlayerCam cam;
    public PlayerMovement pm;
    
    [Header("Climbing")]
    public float climbSpeed;
    public float maxClimbTime;
    private float climbTimer;
    private bool climbing;
    

    [Header("ClimbJumping")]
    public float climbJumpUpForce;
    public float climbJumpBackForce;

    public KeyCode jumpKey = KeyCode.Space;
    public float climbJumps;
    private float climbJumpsLeft;

    [Header("Detection")]
    public float detectionLength;
    public float sphereCastRadius;
    public float maxWallLookAngle;
    private float wallLookAngle;

    private RaycastHit frontWallHit;
    private bool wallFront;

    private Transform lastWall;
    private Vector3 lastWallNormal;
    public float minWallNormalAngleChange;
    
    [Header("Exiting")]
    public bool exitingWall;
    public float exitWallTime;
    private float exitWallTimer;



    // Update is called once per frame
    private void Update()
    {
        WallCheck();
        StateMachine();
        
        if(climbing && !exitingWall) ClimbingMovement();
    }

    private void StateMachine()
    {
        //state 1 - climbing
        if(wallFront && Input.GetKey(KeyCode.W) && wallLookAngle < maxWallLookAngle && !exitingWall)
        {
            if (!climbing && climbTimer > 0) StartClimbing();

            //timer
            if(climbTimer > 0) climbTimer -= Time.deltaTime;
            if(climbTimer < 0) StopClimbing();
        }

        else if (exitingWall)
        {
            if(climbing) StopClimbing();

            if(exitWallTimer>0) exitWallTimer -= Time.deltaTime;
            if(exitWallTimer<0) exitingWall = false;
        }

        //state 3 - none
        else
        {
            if(climbing) StopClimbing();
        }

        if(wallFront && Input.GetKeyDown(jumpKey) && climbJumpsLeft > 0) ClimbJump();
    }

    private void WallCheck()
    {
        wallFront = Physics.SphereCast(transform.position, sphereCastRadius, orientation.forward, out frontWallHit, detectionLength, whatIsWall);
        wallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);

        bool newWall = frontWallHit.transform != lastWall || Mathf.Abs(Vector3.Angle(lastWallNormal, frontWallHit.normal)) >minWallNormalAngleChange;

        if((wallFront && newWall)||pm.grounded)
        {
            climbTimer = maxClimbTime;
            climbJumpsLeft = climbJumps;
        }
    }

    private void StartClimbing()
    {
        climbing = true;
        cam.DoFov(110f);
        pm.climbing = true;

        lastWall = frontWallHit.transform;
        lastWallNormal = frontWallHit.normal;
    }
    private void ClimbingMovement()
    {
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.z);
    }
    private void StopClimbing()
    {
        climbing = false;
        cam.DoFov(100f);
        pm.climbing = false;
    }

    private  void ClimbJump()
    {
        exitingWall = true;
        exitWallTimer = exitWallTime;
        Vector3 forceToApply = transform.up * climbJumpUpForce + frontWallHit.normal * climbJumpBackForce;

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(forceToApply, ForceMode.Force);

        climbJumpsLeft--;
    }
}
