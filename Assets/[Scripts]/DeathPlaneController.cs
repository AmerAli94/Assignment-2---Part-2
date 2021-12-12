// ===============================
// PROGRAM NAME: GAME Programming (T163)
// STUDENT ID : 101206769
// AUTHOR     : AMER ALI MOHAMMED
// CREATE DATE     : Nov 18, 2021
// PURPOSE     : GAME2014_F2021_ASSIGNMENT2_Part1
// SPECIAL NOTES:
// ===============================
// Change History:
// Added respawnable death plane 
//==================================
//==================================
// Change History:
// Make the eagle flip in right direction.
//==================================


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneController : MonoBehaviour
{
    public Transform playerSpawnPoint;
    public EagleEnemyController eagleFlip;

    private void Start()
    {
        eagleFlip.unflip();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = playerSpawnPoint.position;
            eagleFlip.Flip();
         
        }
        else
        {
            other.gameObject.SetActive(false);
        }
    }
}
