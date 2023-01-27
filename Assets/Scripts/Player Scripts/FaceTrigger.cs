using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTrigger : MonoBehaviour
{
    public bool faceTouchingWall;   //says if there is a collider in front of the player that
    private void OnTriggerStay(Collider other)
    {
        if (!other.isTrigger)
        {
            faceTouchingWall = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            faceTouchingWall = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger)
        {
            faceTouchingWall = false;
        }
    }
}
