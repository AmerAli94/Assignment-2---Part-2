// ===============================
// PROGRAM NAME: GAME Programming (T163)
// STUDENT ID : 101206769
// AUTHOR     : AMER ALI MOHAMMED
// CREATE DATE     : Nov 26, 2021
// PURPOSE     : GAME2014_F2021_ASSIGNMENT2_Part1
// SPECIAL NOTES:
// ===============================
// Change History:
// Added Audio manager for various sounds in game
//==================================
//==================================
// Change History:
// 
//==================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // singleton based audio manager

    //Sounds
    public AudioClip jump, landing, firing, damage, pickup , firemiss, enemyHit;
    public AudioSource bGM, winMusic, GameOver;

    public GameObject soundObject;

    public bool isLevelBGMPlaying = true;
    public bool iswinMusicPlaying = false;
    public bool isGameOverPlaying = false;

    void Awake()
    {
        instance = this;
        
    }

    private void Start()
    {
        bGM.Play();
    }

    public void PlaySound(string soundName)
    {
        switch(soundName)
        {
            case "jump":
                CreateSoundObject(jump);
                break;
            case "landing":
                CreateSoundObject(landing);
                break;
            case "enemyfire":
                CreateSoundObject(firing);
                break;
            case "playerhit":
                CreateSoundObject(damage);
                break;
            case "pickup":
                CreateSoundObject(pickup);
                break;
            case "firemiss":
                CreateSoundObject(firemiss);
                break;
            case "enemyHit":
                CreateSoundObject(enemyHit);
                break;


        }
    }

    //using one function to instantiate the sound as an object and play it.

    public void CreateSoundObject(AudioClip clip)
    {
        //Instantiate sound object
        GameObject newObject = Instantiate(soundObject, transform);


        //Assign AudioClip 
        newObject.GetComponent<AudioSource>().clip = clip;

        newObject.GetComponent<AudioSource>().Play();

    }

    public void PlayLevelBGM()
    {
        isLevelBGMPlaying = true;
        iswinMusicPlaying = false;
        isGameOverPlaying = false;
        
        bGM.Play();
    }

    public void PlayWinMusic()
    {
        if (bGM.isPlaying)
            isLevelBGMPlaying = false;
        {
            bGM.Stop();
        }

        if (!winMusic.isPlaying && iswinMusicPlaying == false)
        {
            winMusic.Play();
            iswinMusicPlaying = true;
        }
    }

    public void PlayGameOverMusic()
    {
        if (bGM.isPlaying)
            isLevelBGMPlaying = false;
        {
            bGM.Stop();
        }

        if (!winMusic.isPlaying && iswinMusicPlaying == false)
        {
            GameOver.Play();
            isGameOverPlaying = true;
        }
    }
}
