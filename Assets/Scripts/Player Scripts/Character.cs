using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Character : HealthBase
{
    [Header("References to things")]
    public FaceTrigger faceTriggerScript;   //the face trigger script, used for making sure the player doesnt walk through walls
    public Rigidbody playerRb;  
    [SerializeField] Collider feetCollider; //the feet trigger, for grounded checks
    public PlayerScriptManager playerScriptManager; //script handling the switching of player characters

    [Header("Movement Variables")]
    public float moveSpeed = 5.0f; // the speed at which the player will move
    public float moveEquipmentMultiplier = 1;   //changes depending on equipment
    private float moveFloat;        //the x value of the movement joystick
    public Vector3 moveVectorData;  //the input data from the character input script
    public bool playerTouchingGround;   
    [SerializeField] float maxVerticalSpeed;
    [SerializeField] float maxHorizontalSpeed;

    [Header("Jumping Variables")]
    [SerializeField] int allowedCallsOfJumpCo; // how many times the jump coroutine can be called
    [SerializeField] float timePerCallJumpCo;   //time between each call
    [SerializeField] float jumpForce;           //the force added upon each call
    public float jumpEquipmentMultiplier = 1;   //changes depending on equipment
    [SerializeField] float minJumpForce;        //the minimum jump force added
    [SerializeField] float sizeJumpModifier = 1.4f; //how much the scale of the player should impact the jump force
    public int jumpCharges; //amount of times the player can jump in a row
    public bool isGrounded;
    public int resetJumpCharges;    //how many jump charges the plpayer should get upon touching the ground
    public bool isHoldingJump;      //if the player is holding down the jump button

    [Header("Other")]
    public Vector3 specialStickVector;  //the input vector for the special stick, used by the Size character
    [SerializeField] TextMeshProUGUI healthUiText;  //text for the health value

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void FixedUpdate()
    {
        Move(); //calls the movement function every fixed update
    }

    //the movement function that can be overriden by inherited classes
    public virtual void Move()
    {
        moveFloat = moveVectorData.x * transform.localScale.x;  //the movefloat is dependant on the left stick

        //rotates the player depending on the movement input
        if (moveFloat < 0f)
        {
            playerRb.transform.rotation = Quaternion.Euler(playerRb.transform.rotation.x, 180, playerRb.transform.rotation.z);
        }
        else if (moveFloat > 0f)
        {
            playerRb.transform.rotation = Quaternion.Euler(playerRb.transform.rotation.x, 0, playerRb.transform.rotation.z);
        }

        //Moving Player left and right without changing the vertical speed
        if (!isGettingKnockedbacked)
        {
            if(faceTriggerScript.faceTouchingWall && moveFloat > 0)
            {
                moveFloat = 0;
            }
            else if (faceTriggerScript.faceTouchingWall && moveFloat < 0)
            {
                moveFloat = 0;
            }
            playerRb.MovePosition(transform.position + Vector3.right * moveFloat * moveSpeed * moveEquipmentMultiplier);    //moves the position of the player

            //clamps the players velocity
            if (playerRb.velocity.x > maxHorizontalSpeed * transform.localScale.x)
            {
                playerRb.velocity = new Vector3(maxHorizontalSpeed * transform.localScale.x, playerRb.velocity.y, playerRb.velocity.z);
            }
            else if (playerRb.velocity.x < -maxHorizontalSpeed * transform.localScale.x)
            {
                playerRb.velocity = new Vector3(-maxHorizontalSpeed * transform.localScale.x, playerRb.velocity.y, playerRb.velocity.z);
            }
        }
    }
    //checks if the player can jump does so if it can
    public virtual void JumpCheck()
    {
        if(jumpCharges > 0)
        {
            if(!isHoldingJump && this)
            {
                StartCoroutine(Jump());     //Starts the jumping coroutine
                StartCoroutine(restartGroundedCheck());     //Temporarily disables the feet collider so that you dont gain an additional jump charge as the feet collider may still be touching the ground right after the jump
            }    
        }
    }

    //the jumping coroutine
    public virtual IEnumerator Jump()
    {
        isGrounded = false;
        isHoldingJump = true;   //bool used to stop the jump coroutine
        playerRb.velocity = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);           //sets y velocity to 0
        playerRb.AddForce(Vector3.up * minJumpForce * jumpEquipmentMultiplier * transform.localScale.y / Time.timeScale, ForceMode.Impulse);     //adds the minimum force
        jumpCharges--;

        int numberOfCalls = 1;                      
        while (numberOfCalls < allowedCallsOfJumpCo && isHoldingJump) //The jumping coroutine only gets called a set number of times
        {
            yield return new WaitForSecondsRealtime(timePerCallJumpCo);                 //Time between every call
            playerRb.AddForce(Vector3.up * jumpForce * jumpEquipmentMultiplier * Mathf.Pow(transform.localScale.y, sizeJumpModifier) / Time.timeScale, ForceMode.Impulse);       //Applies Jumping Force
            numberOfCalls++;            //Call count increased
        }
    }

    //disables the feet trigger that handles ground collition in relation to jump variables for a bit
    //makes it so you cant get an additional jump charge on the way up
    public IEnumerator restartGroundedCheck()
    {
        playerTouchingGround = false;
        feetCollider.enabled = false;
        yield return new WaitForSecondsRealtime(0.2f);
        feetCollider.enabled = true;
    }

    //these functions get called by the character input script and used overriden by inherhited classes
    public virtual void SpecialButtonDown()
    {
    }
    public virtual void SpecialButtonUp()
    {
    }

    //called by the HealthBase class, which this class inherits from, when the player has zero health
    public override void HasZeroHealth()
    {
        GameManager.instance.LoadCheckpoint();  //loads the last checkpoint when the player has 0 health
    }
    public override void TookDamage()
    {
        healthUiText.text = "Health: " + healthValue.ToString();    //updates the health text whenever the player takes damage
    }
}
