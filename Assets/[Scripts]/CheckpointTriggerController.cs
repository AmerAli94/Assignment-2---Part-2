using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTriggerController : MonoBehaviour
{
    public Transform spawnPoint;

    private GameContoller gameContoller;
    // Start is called before the first frame update
    void Start()
    {
        gameContoller = GameObject.FindObjectOfType<GameContoller>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameContoller.SetCurrentSpawnPoint(spawnPoint);
            Debug.Log("collided");
        }
    }

}
