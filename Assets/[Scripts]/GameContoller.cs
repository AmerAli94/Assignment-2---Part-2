// ===============================
// PROGRAM NAME: GAME Programming (T163)
// STUDENT ID : 101206769
// AUTHOR     : AMER ALI MOHAMMED
// CREATE DATE     : Nov 18, 2021
// PURPOSE     : GAME2014_F2021_ASSIGNMENT2_Part1
// SPECIAL NOTES:
// ===============================
// Change History:
// 
//==================================
//==================================
// Change History:
// 
//==================================



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoller : MonoBehaviour
{
    public Transform player;
    public Transform playerSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        player.position = playerSpawnPoint.position;
        Time.timeScale = 1.0f;
    }
    
}
