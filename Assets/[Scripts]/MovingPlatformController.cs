// ===============================
// PROGRAM NAME: GAME Programming (T163)
// STUDENT ID : 101206769
// AUTHOR     : AMER ALI MOHAMMED
// CREATE DATE     : Nov 18, 2021
// PURPOSE     : GAME2014_F2021_ASSIGNMENT2_Part1
// SPECIAL NOTES:
// ===============================
// Change History:
// Platform and eagle enemy movement controller
//==================================
//==================================
// Change History:
// 
//==================================



using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    [Header("Movement")]
    public MovingPlatformDirection direction;
    [Range(0.0f, 10.0f)]
    public float speed;

    [Range(1 , 20)]
    public float distance;
    [Range(0.05f, 0.1f)]
    public float distanceOffset;
    public bool isLooping;

    private Rigidbody2D rb;
    private Vector2 startingPosition;
    private bool isMoving;

    // Start is called before the first frame update
    public void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
        isMoving = true;
    }

    // Update is called once per frame
   public void Update()
    {
        MovePlatform();

        if(isLooping)
        {
            isMoving = true;
        }
    }

    

    private void MovePlatform()
    {
        float pingPongValue = (isMoving) ? Mathf.PingPong(Time.time * speed, distance) : distance;

        if ((!isLooping) && (pingPongValue >= distance - distanceOffset))
        {
            isMoving = false;
        }

        switch (direction)
        {
            case MovingPlatformDirection.HORIZONTAL:
                Vector2 moveHorizontal = new Vector2(startingPosition.x + pingPongValue, transform.position.y);
                rb.MovePosition(moveHorizontal); //moving using rigidbody because of weird jittery issues/ still have it with vertical movement
                break;
            case MovingPlatformDirection.VERTICAL:
                Vector2 moveVertical = transform.position = new Vector2(transform.position.x, startingPosition.y + pingPongValue);
                rb.MovePosition(moveVertical);

                break;
            case MovingPlatformDirection.DIAGONAL_UP:
                //transform.position = new Vector2();
                Vector2 moveDiagonalUp = transform.position = new Vector2(startingPosition.x + pingPongValue, startingPosition.y + pingPongValue);
                rb.MovePosition(moveDiagonalUp);

                break;
            case MovingPlatformDirection.DIAGONAL_DOWN:
                transform.position = new Vector2(startingPosition.x - pingPongValue, startingPosition.y - pingPongValue);
                break;
        }
    }

    //public void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        // transform.SetParent(other.transform);
    //        other.transform.parent = transform;
    //        //rb.velocity = other.relativeVelocity;
    //        other.rigidbody.velocity = rb.velocity;
    //        AudioManager.instance.PlaySound("landing");

    //    }
    //}

    //public void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Player") )
    //    {
    //        // transform.SetParent(null);
    //        other.transform.parent = null;
    //        AudioManager.instance.PlaySound("jump");
    //    }
    //}
}
