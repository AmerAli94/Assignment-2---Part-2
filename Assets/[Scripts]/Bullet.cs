// ===============================
// PROGRAM NAME: GAME Programming (T163)
// STUDENT ID : 101206769
// AUTHOR     : AMER ALI MOHAMMED
// CREATE DATE     : Nov 25, 2021
// PURPOSE     : GAME2014_F2021_ASSIGNMENT2_Part1
// SPECIAL NOTES:
// ===============================
// Change History:
// Added bullets for flying eagle enemy with shooting capability
//==================================
//==================================
// Change History:
// Added player location as target for the bullet to move to after spawning
//==================================
// Change History:
// Added Explosions to the bullet.
//==================================


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Manager")]
    GameObject bulletSpawnPoint;
    public GameObject explosion;
    public float speed = 5.0f;
    public int damage = 1;
    private Rigidbody2D rb;




    // Start is called before the first frame update
    void Start()
    {
        //only one check in start so the bullet doesn't keep following the player.
        rb = GetComponent<Rigidbody2D>();
        bulletSpawnPoint = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (bulletSpawnPoint.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDir.x, moveDir.y);      

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health player = other.GetComponent<Health>();
        rb.velocity = new Vector2(0, 0);
        if (player != null)
        {
            player.TakeDamage(damage);
        }
        //Playing the sound when the bullet is not hitting the player.
        AudioManager.instance.PlaySound("firemiss");

        // Instantiating as a variable so that I can destroy it later. Hard learned lesson
        GameObject platformHittingExplosions = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(platformHittingExplosions, 0.3f);

        if (other.gameObject.CompareTag("Player"))
        {
            //Playing the sound when the bullet is hitting the player.
            AudioManager.instance.PlaySound("playerhit");

           GameObject explosionEffect =  Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explosionEffect, 0.4f);

        }
        Destroy(this.gameObject, 0.3f);


    }




}
