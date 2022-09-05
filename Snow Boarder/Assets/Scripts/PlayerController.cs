using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        // Gets access to an component within the inspector under Rigidbody2D
        rb2d = GetComponent<Rigidbody2D>();

        // Gets access to an component from a different object thats
        // under SurfaceEffector 2D
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate an object around its Y (upward) axis in response to
        // left/right controls
        if(canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisabledControls()
    {
        canMove = false;
    }

    void RespondToBoost()
    {
        // if we push up, then push up
        // otherwise stay at normal speed
        // access the SurfaceEffector2d and change its speed
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // this allows to use the component under Rigidbody2D
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
