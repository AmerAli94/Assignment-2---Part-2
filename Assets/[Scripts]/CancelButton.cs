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


public class CancelButton : MonoBehaviour
{

    public Animator animator;
   

    private float WaitforcancelLoad = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCancelPressed()
    {
        animator.SetBool("IsActive", true);
        StartCoroutine(CancelGame());
       // Debug.Log("Cancel Pressed");
    }

    IEnumerator CancelGame()
    {
        yield return new WaitForSeconds(WaitforcancelLoad);
        Application.Quit();
    }

}
