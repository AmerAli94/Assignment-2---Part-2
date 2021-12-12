using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathPanel : MonoBehaviour
{

    //public Text collectedStarsText;
    public Text starScore;

    int score; 

    public void Start()
    {
       

    }

    public void Update()
    {
        //using Player prefs to save and load the score
        int collectedStars = PlayerPrefs.GetInt("Collected Stars");
        score = collectedStars;
        starScore.text = "- " + score.ToString();
    }
    public void OnReplayPressed()
    {
        AudioManager.instance.PlaySound("buttonPress");

        SceneManager.LoadScene("Main");
    }

    public void OnMenuPresses()
    {
        AudioManager.instance.PlaySound("buttonPress");

        SceneManager.LoadScene("Menu");
    }

    public void OnQuitPressed()
    {
        AudioManager.instance.PlaySound("buttonPress");

        Application.Quit();
    }
}
