// ===============================
// PROGRAM NAME: GAME Programming (T163)
// STUDENT ID : 101206769
// AUTHOR     : AMER ALI MOHAMMED
// CREATE DATE     : Nov 18, 2021
// PURPOSE     : GAME2014_F2021_ASSIGNMENT2_Part1
// SPECIAL NOTES:
// ===============================
// Change History:
// Added player and player animation
//==================================
//==================================
// Change History:
// 
//==================================



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Touch Input")]
    public Joystick joystick;
    [Range(0.01f,1.0f)]
    public float sensitivity;

    [Header("Movement")] 
    public float horizontalForce;
    public float verticalForce;
    public bool isGrounded;
    public Transform groundOrigin;
    public float groundRadius;

    public LayerMask groundLayerMask;
   [Range(0.1f,0.9f)]
    public float airControlFactor;

    [Header("Animation")]
    public PlayerAnimationState state;


    private int damage = 1;

    private Rigidbody2D rb;
    private Animator animatorController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorController = GetComponent<Animator>();

    }

    // Update is called once per frame

    private void Update()
    {
        
       // Debug.Log(verticalForce);

    }
    void FixedUpdate()
    {
        Move();
        CheckIfGrounded();
    }

    private void Move()
    {
        float x = (Input.GetAxisRaw("Horizontal") + joystick.Horizontal) * sensitivity; ;

        if (isGrounded)
        {
            

            // Keyboard Input
            
            float y = (Input.GetAxisRaw("Vertical") + joystick.Vertical) * sensitivity;
            float jump = Input.GetAxisRaw("Jump") + ((UIController.jumpButtonDown) ? 1.0f : 0.0f);

            // Check for Flip

            if (x != 0)
            {
                x = FlipAnimation(x);
                animatorController.SetInteger("AnimationState", (int) PlayerAnimationState.RUN); //Run State
                state = PlayerAnimationState.RUN;
            }
            else
            {
                animatorController.SetInteger("AnimationState", (int)PlayerAnimationState.IDLE); //Idle State
                state = PlayerAnimationState.IDLE;
            }

            //Touch Input
            //Vector2 worldTouch = new Vector2();
            //foreach (var touch in Input.touches)
            //{
            //    worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
            //}

            float horizontalMoveForce = x * horizontalForce;
            float jumpMoveForce = jump * verticalForce; 

            float mass = rb.mass * rb.gravityScale;


            rb.AddForce(new Vector2(horizontalMoveForce, jumpMoveForce) * mass);
            rb.velocity *= 0.99f; // scaling / stopping hack

        }
        else // Air Control
        {
            animatorController.SetInteger("AnimationState", (int)PlayerAnimationState.JUMP); // Jump State
            state = PlayerAnimationState.JUMP;
            //
            // rb.velocity = Vector2.zero;
           


            if (x != 0)
            {
                x = FlipAnimation(x);

                float horizontalMoveForce = x * horizontalForce * airControlFactor;
                float mass = rb.mass * rb.gravityScale;

                rb.AddForce(new Vector2(horizontalMoveForce, 0.0f) * mass);
            }
        }
    }

    private void CheckIfGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(groundOrigin.position, groundRadius, Vector2.down, groundRadius, groundLayerMask);

        isGrounded = (hit) ? true : false;


    }

    private float FlipAnimation(float x)
    {
        // depending on direction scale across the x-axis either 1 or -1
        x = (x > 0) ? 1 : -1;

        transform.localScale = new Vector3(x, 1.0f);
        return x;
    }


    // UTILITIES

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundOrigin.position, groundRadius);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform") || other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(other.transform);

            AudioManager.instance.PlaySound("landing");

        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Health player = GetComponent<Health>();
            // rb.velocity = new Vector2(0, 0);
            AudioManager.instance.PlaySound("enemyHit");
            player.TakeDamage(damage);
            Debug.Log("collided");
        }



    }

    private void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Platform") || other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(null);
            AudioManager.instance.PlaySound("jump");
        }
    }


}
