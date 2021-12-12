// PROGRAM NAME: GAME Programming (T163)
// STUDENT ID : 101206769
// AUTHOR     : AMER ALI MOHAMMED
// CREATE DATE     : Nov 26, 2021
// PURPOSE     : GAME2014_F2021_ASSIGNMENT2_Part1
// SPECIAL NOTES:
// ===============================
// Change History:
// Pickup scripts for player detection
//==================================
//==================================
// Change History:
// Added score
//==================================


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //adding a point to the score.
            ScoreManager.instance.AddPoint();
            AudioManager.instance.PlaySound("pickup");
            //Debug.Log("Pick up");
            Destroy(gameObject);
        }
    }
}
