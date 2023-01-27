using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //if the checkpoint collides with the player then update the game managers variables relating to checkpoints and then save the game
        if (other.CompareTag("Player") && GameManager.instance.currentCheckpoint != gameObject)
        {
            GameManager.instance.currentCheckpoint = gameObject;
            GameManager.instance.currentCheckpointLevelIndex = SceneManager.GetActiveScene().buildIndex;
            GameManager.instance.SaveGame();
        }
    }
}
