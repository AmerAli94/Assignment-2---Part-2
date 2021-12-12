// ===============================
// PROGRAM NAME: GAME Programming (T163)
// STUDENT ID : 101206769
// AUTHOR     : AMER ALI MOHAMMED
// CREATE DATE     : Nov 29, 2021
// PURPOSE     : GAME2014_F2021_ASSIGNMENT2_Part2
// SPECIAL NOTES:
// ===============================
// Change History:
// Added Pause Screen
//==================================
//==================================
// Change History:
// 
//==================================


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        //enabling and disabling the pause creen box game objects
        pausePanel.GetComponent<GameObject>();
        pausePanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPausePressed()
    {
        AudioManager.instance.PlaySound("buttonPress");
        pausePanel.SetActive(true);

        //pausing time in game
        Time.timeScale = 0.0f;
    }

    public void OnResumePressed()
    {
        AudioManager.instance.PlaySound("buttonPress");

        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void OnCancelPressed()
    {
        AudioManager.instance.PlaySound("buttonPress");

        Application.Quit();
    }

    public void OnMenuPressed()
    {
        AudioManager.instance.PlaySound("buttonPress");

        SceneManager.LoadScene("Menu");

    }

    public void OnRetryPressed()
    {
        AudioManager.instance.PlaySound("buttonPress");

        StartCoroutine(LoadMain());
    }

    private IEnumerator LoadMenu()
    {

        yield return new WaitForSeconds(1);
    }

    private IEnumerator LoadMain()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Main");
    }

}
