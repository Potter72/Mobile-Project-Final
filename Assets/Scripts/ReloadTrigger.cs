using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadTrigger : MonoBehaviour
{
    //loads the current checkpoint if collides with the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            GameManager.instance.LoadCheckpoint();
        }
    }
}
