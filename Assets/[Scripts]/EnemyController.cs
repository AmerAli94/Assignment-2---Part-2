// ===============================
// PROGRAM NAME: GAME Programming (T163)
// STUDENT ID : 101206769
// AUTHOR     : AMER ALI MOHAMMED
// CREATE DATE     : Nov 18, 2021
// PURPOSE     : GAME2014_F2021_ASSIGNMENT2_Part1
// SPECIAL NOTES:
// ===============================
// Change History:
// Added Possum enemy comtroller
//==================================
//==================================
// Change History:
// 
//==================================


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Player Detection")]
    public LOS enemyLOS;
     

    [Header("Movement")]
    public float runForce;
    
    public Transform lookAheadPoint;
    public Transform lookInFrontPoint;
    public LayerMask groundLayerMask;
    public LayerMask wallLayerMask;

    //BoxCollider2D boxCollider;
    //private int damage = 1;



    [Header("Animator")]
    public Animator animatorControler;

    private Rigidbody2D rigibody;


    public bool isGroundAhead;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyLOS = GetComponent<LOS>();
        animatorControler = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LookAhead();
        LookInFrontPoint();
        MoveEnemy();

        if (!HasLOS())
        {
            animatorControler.enabled = true;
            animatorControler.Play("Run");


        }

        else 
        {
            //animatorControler.enabled = false;;
        }
    }


    private bool HasLOS()
    {
        string playerTag = "Player";

        if (enemyLOS.colliderList.Count > 0)
        {
            // case 1 enemy polygoncollider collides with player & is at the top of the list
            if((enemyLOS.collidesWith.gameObject.CompareTag("Player")) &&
                (enemyLOS.colliderList[0].gameObject.CompareTag("Player")))
            {
                return true;
            }
            else 
            {
                //case 2 player is in the collider list and we can draw ray to the player
                foreach (var collider in enemyLOS.colliderList)
                {

                    if(collider.CompareTag("Player"))
                    {
                        RaycastHit2D hit = (Physics2D.Linecast(transform.position, collider.transform.position , enemyLOS.contactFilter.layerMask));
                        if(hit && hit.collider.gameObject.CompareTag(playerTag))
                        {
                            return true;
                        }
                       
                    }
                }
            }
        }
        return false;
    }

    private void LookInFrontPoint()
    {
        var hit = Physics2D.Linecast(transform.position, lookInFrontPoint.position, wallLayerMask);
        if (hit)
        {
            Flip();
        }
    }

    private void LookAhead()
    {
        var hit = Physics2D.Linecast(transform.position, lookAheadPoint.position, groundLayerMask);
        isGroundAhead = (hit) ? true : false;
    }

    private void MoveEnemy()
    {
        if (isGroundAhead)
        {
            rb.AddForce(Vector2.left * runForce * transform.localScale.x);
            rb.velocity *= 0.90f;
        }
        else
        {
            Flip();
        }
    }

    private void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(other.transform);
        }

     
        if (other.gameObject.CompareTag("Player"))
        {
            animatorControler.enabled = false;
        

        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null);
        }


    }

    //Utilities

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, lookAheadPoint.position);
        Gizmos.DrawLine(transform.position, lookInFrontPoint.position);
    }
}
