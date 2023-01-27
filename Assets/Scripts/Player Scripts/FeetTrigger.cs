using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetTrigger : MonoBehaviour
{
    public Character playerScript; //is re-asigned whenever the player switches character by the player script manager

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))  //Checks if feet is exiting collision with the ground
        {
            StartCoroutine(IsInAir());              //start the in air coroutine
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))  //Checks if feet is colliding with the ground
        {
            playerScript.jumpCharges = playerScript.resetJumpCharges;   //Resets the jumpcharged of the main player movement script
            playerScript.isGrounded = true;
        }
    }

    /// <summary>
    /// the in IsInAir more or less fixes a bug where if the player walks between two colliders without leaving the ground it would count as going in the air
    /// this behaviour could be fixed by changing the grounded checking by using raycasts instead of a trigger collider for the feet but its not a major bug at the moment
    /// this solution also lets you jump for a small amount of time after walking off an edge which i've heard is something that improves the feeling of the movement
    /// </summary>
    IEnumerator IsInAir()
    {
        playerScript.isGrounded = false;
        yield return new WaitForSecondsRealtime(0.04f);     //waits a short while to make sure the player really is in the air 
        if (!playerScript.isGrounded)                  //if the player still isnt on the ground
        {
            if (playerScript.jumpCharges > playerScript.resetJumpCharges - 1) playerScript.jumpCharges -= 1;    //if the player has max jump charges when leaving the ground without jumping then decrease the jump charges by 1
            playerScript.isGrounded = false;
        }
    }
}
