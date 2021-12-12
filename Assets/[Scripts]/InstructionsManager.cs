// ===============================
// PROGRAM NAME: GAME Programming (T163)
// STUDENT ID : 101206769
// AUTHOR     : AMER ALI MOHAMMED
// CREATE DATE     : Nov 26, 2021
// PURPOSE     : GAME2014_F2021_ASSIGNMENT2_Part1
// SPECIAL NOTES:
// ===============================
// Change History:
// Added slidable Instructions Screen as part of UI
//==================================
//==================================
// Change History:
// Added instruction boxes.
//==================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsManager : MonoBehaviour
{
    
    public Animator instructionsBoxAnimator;
    public Animator animator;

    [Header("InstructionBoxes")]
    public GameObject firstInstructionBox;
    public GameObject secondInstructionBox;
    public GameObject thirdInstructionsBox;

    private float waitForAnimBool = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        //Using bools as parameters to activate the animations
        instructionsBoxAnimator.SetBool("IsOpenActive", false);
        animator.SetBool("IsActive", false);
        firstInstructionBox.SetActive(true);
        secondInstructionBox.SetActive(false);
        thirdInstructionsBox.SetActive(false);
        //Debug.Log(instructionsBoxAnimator);
    }


    public void OnInstructionsButtonPressed()
    {
        
        instructionsBoxAnimator.SetBool("IsOpenActive", true);
        instructionsBoxAnimator.SetBool("IsCloseActive", false);
        animator.SetBool("IsActive", true);
        firstInstructionBox.SetActive(true);
        secondInstructionBox.SetActive(false);
        thirdInstructionsBox.SetActive(false);

        StartCoroutine(ChangeAnimatorBool());
    }

    public void OnFirstInstructionsBoxNextPressed()
    {
        //using set active for gameobjects to hide & show Instructions screens/panels
        firstInstructionBox.SetActive(false);
        secondInstructionBox.SetActive(true); // activate only 2nd box
        thirdInstructionsBox.SetActive(false);
    }

    public void OnSecInstructionsBoxPrevButtonPres()
    {
        secondInstructionBox.SetActive(false);
        firstInstructionBox.SetActive(true); // activate only 1st box
        thirdInstructionsBox.SetActive(false);

    }

    public void OnSecInstructionsBoxNextButtonPres()
    {
        secondInstructionBox.SetActive(false);
        firstInstructionBox.SetActive(false); 
        thirdInstructionsBox.SetActive(true); // activate only 3rd box

    }

    public void OnThirdInstructionsBoxPrevButtonPres()
    {
        secondInstructionBox.SetActive(true); // activate only 2nd box
        firstInstructionBox.SetActive(false); 
        thirdInstructionsBox.SetActive(false);

    }

    public void OnInstructionBoxCancelPress()
    {
        instructionsBoxAnimator.SetBool("IsOpenActive", false);
        instructionsBoxAnimator.SetBool("IsCloseActive", true);
    }

    //using coroutines to deactvate the bools for reuse or button represses
    IEnumerator ChangeAnimatorBool()
    {
        yield return new WaitForSeconds(waitForAnimBool);
        animator.SetBool("IsActive", false);
    }






}
