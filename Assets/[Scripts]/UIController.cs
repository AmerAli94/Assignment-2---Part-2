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

public class UIController : MonoBehaviour
{

    [Header("Button Control Events")]
    public static bool jumpButtonDown;


    [Header("On Screen Controls")]
    public GameObject onScreenControls;

    
    // Start is called before the first frame update
    void Start()
    {
        CheckPlatform();
    }

    // Private Methods

    private void CheckPlatform()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
            case RuntimePlatform.IPhonePlayer:
            case RuntimePlatform.WindowsEditor:
                onScreenControls.SetActive(true);
                break;
            default:
                onScreenControls.SetActive(false);
                break;
        }
    }

    public void OnJumpButton_Down()
    {
        jumpButtonDown = true;
    }

    public void OnJumpButton_Up()
    {
        jumpButtonDown = false;

    }
}
