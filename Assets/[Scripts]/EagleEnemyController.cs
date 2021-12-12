// ===============================
// PROGRAM NAME: GAME Programming (T163)
// STUDENT ID : 101206769
// AUTHOR     : AMER ALI MOHAMMED
// CREATE DATE     : Nov 25, 2021
// PURPOSE     : GAME2014_F2021_ASSIGNMENT2_Part1
// SPECIAL NOTES:
// ===============================
// Change History:
// Added shooting eagle enemy with trajactery like falling bullets
//==================================
//==================================
// Change History:
// Scrapped the trajectary movement and added falling movement of bullets with time based spawning and collider based enemy transform flip
//==================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EagleEnemyController : MonoBehaviour
{
    public float timeBwShots;

    [Header("Bullets")]
    public GameObject shootingPos;
    public GameObject bullet;
    public float shootingRange;
    public float shootingSpeed;
    public float shootingRate;

    private Transform playerTransform;
    private float nextShootTime;
    private bool isShooting;

 
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        unflip(); // makes sure enemy facing right direction upon repawn

        isShooting = true;
    }

    public void Update()
    {
     
        if (isShooting)
        {
            Shoot();

        }
        else
        {
            StopShooting();
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Flip();
        }
    }

    public void Shoot()
    {
      //  isShooting = true;
        float distanceFromPlayer = Vector2.Distance(playerTransform.position, transform.position);

        if (distanceFromPlayer < shootingRange && nextShootTime < Time.time)
        {
            GameObject shoot = Instantiate(bullet, shootingPos.transform.position, Quaternion.identity);
            AudioManager.instance.PlaySound("enemyfire");
            nextShootTime = Time.time + shootingRate;
            //isShooting = false;

            Destroy(shoot, 5);
        }

    }

    public void StopShooting()
    {
        timeBwShots = 10.0f;
        if(isShooting)
        isShooting = false; // gets called in win state so that the enemies don't keep on shooting when the win screen anim is played

    }




    public void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
    
    }

    public void unflip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
    }
}
