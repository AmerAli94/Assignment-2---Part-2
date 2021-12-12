// ===============================
// PROGRAM NAME: GAME Programming (T163)
// STUDENT ID : 101206769
// AUTHOR     : AMER ALI MOHAMMED
// CREATE DATE     : Nov 26, 2021
// PURPOSE     : GAME2014_F2021_ASSIGNMENT2_Part1
// SPECIAL NOTES:
// ===============================
// Change History:
// Added for Main Menu UI. 
//==================================
//==================================
// Change History:
// 
//==================================


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayButton : MonoBehaviour
{

    public Animator animator;
    private float WaitforMenuLoad = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f; // so that after dying when we reload level the level is not paused
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnStartPressed()
    {
        animator.SetBool("IsActive", true);
        StartCoroutine(LoadMenu());
        Debug.Log("Start Pressed");
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(WaitforMenuLoad);
        SceneManager.LoadScene("Main");
    }
}
