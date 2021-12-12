// PROGRAM NAME: GAME Programming (T163)
// STUDENT ID : 101206769
// AUTHOR     : AMER ALI MOHAMMED
// CREATE DATE     : Nov 26, 2021
// PURPOSE     : GAME2014_F2021_ASSIGNMENT2_Part1
// SPECIAL NOTES:
// ===============================
// Change History:
// Added player health UI and damage
//==================================
//==================================
// Change History:
// Added Death Sceen
//==================================


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfLives;
    public Animator playerDeathAnnim;
    public Image[] lives;
    public Sprite remainingLives;
    public Sprite emptyLifeSlots;
    public GameObject deathPanel;

    void Start()
    {
        playerDeathAnnim.GetComponent<Animator>();
        deathPanel.GetComponent<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        if(health > numOfLives)
        {
            health = numOfLives;
        }

        for (int i= 0; i < lives.Length; i++)
        {
            if(i< health) 
            {
                lives[i].sprite = remainingLives; // displaying lives when player has enough of health
           
            }
            else
            {
                lives[i].sprite = emptyLifeSlots; // displaying empty slots when the player lose health
            }

            if (i < numOfLives) // enabling lives sprites in the array according to the numoflives
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }
        }
    }
     public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Debug.Log("Game over");
            playerDeathAnnim.SetBool("IsDeathActive", true);
            FindObjectOfType<AudioManager>().PlayGameOverMusic();
            FindObjectOfType<EagleEnemyController>().StopShooting();
            deathPanel.SetActive(true);
            Time.timeScale = 0.0f;
            
        }
    }
}
