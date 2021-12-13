// PROGRAM NAME: GAME Programming (T163)
// STUDENT ID : 101206769
// AUTHOR     : AMER ALI MOHAMMED
// CREATE DATE     : Dec 26, 2021
// PURPOSE     : GAME2014_F2021_ASSIGNMENT2_Part2
// SPECIAL NOTES:
// ===============================
// Change History:
// Pickup scripts for player detection
//==================================
//==================================
// Change History:
// Added score
//==================================
// Change History:
// Added random colored pickups
//==================================


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pickup : MonoBehaviour
{
    [Header("Pickup items")]
    public GameObject yellowStar;
    public GameObject redStar;
    public GameObject greenStar;
    public int num;


    private Transform playerTransform;
    

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        num = Random.Range(1,4); // generating a random number between 3 values.

    }

    private void Update()
    {
        if (num == 1)
        {
            
            yellowStar.SetActive(true); // Activates yellow
            redStar.SetActive(false);
            greenStar.SetActive(false);


        }
        if (num == 2)
        {
            redStar.SetActive(true); // Activates red
            greenStar.SetActive(false);
            yellowStar.SetActive(false);

        }
        if (num == 3)
        {
            greenStar.SetActive(true); // Activates green
            redStar.SetActive(false);
            yellowStar.SetActive(false);
        }
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
