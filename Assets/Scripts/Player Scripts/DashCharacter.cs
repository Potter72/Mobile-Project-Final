using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DashCharacter : Character
{

    [Header("Variables for the jetpack/dash character")]
    [SerializeField] float startJumpheight;     //how far up the player should jump before beginning flying if its on the ground when StartFlying is called
    [SerializeField] float startJumpSpeed;      //how fast this should happen
    [SerializeField] AnimationCurve jumpAnimationCurve; //animation curve for the jump
    private bool isFlying;
    [SerializeField] float flySpeed;    //how fast if should fly
    private Vector3 moveVector;     //movement input data
    [SerializeField] float originalGravity = -9.82f;
    [SerializeField] Vector3 originalPlayerConstantForce = new Vector3(0,-270,0);   //the constant force the player should get if its stops flying while time is slowed
    private Vector3 flyPositionMoved;   //the direction the player moved
    private Vector3 oldFlyPosition;
    private Vector3 newFlyPosition;

    private void OnDisable()
    {
        //stops flying if another character is selected
        if (isFlying)
        {
            StopFlying();
        }
    }
    
    //when the special button is pressed checks if the player is flying, if it isnt then it starts flying and if it is then it stops
    public override void SpecialButtonDown()
    {
        if (playerScriptManager.activeCharacterScript == this)
        {
            if (!isFlying)
            {
                StartCoroutine(StartFlying());
            }
            else
            {
                StopFlying();
            }
        }
    }
    
    //stops flying
    private void StopFlying()
    {
        Physics.gravity = new Vector3(0,originalGravity,0);
        GetComponent<ConstantForce>().force = originalPlayerConstantForce;
        isFlying = false;
    }

    // movement/flying function
    public override void Move()
    {
        //if its not flying then the normal move is used
        if (!isFlying && !isGettingKnockedbacked)
        {
            base.Move();
        }
        else if (isFlying && !isGettingKnockedbacked)
        {
            //calculates the direction of movement
            newFlyPosition = transform.position;
            flyPositionMoved = oldFlyPosition - newFlyPosition;
            oldFlyPosition = transform.position;

            moveVector = new Vector2(moveVectorData.x, moveVectorData.y) * transform.localScale;    //changes the movevector depending on the scale 

            if (moveVector != Vector3.zero)
            {
                //rotates the player towards the direction of movement
                if(flyPositionMoved != Vector3.zero)
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(flyPositionMoved, Vector3.forward) * Quaternion.Euler(-90, 0, 0), Mathf.Clamp01(90 * Time.deltaTime));

                playerRb.MovePosition(transform.position + moveVector * flySpeed);  //moves the player 
            }
        }
    }

    IEnumerator StartFlying()
    {
        GetComponent<ConstantForce>().force = Vector3.zero;

        //originalGravity = Physics.gravity.y;
        Physics.gravity = Vector3.zero;
        playerRb.velocity = Vector3.zero;

        if (isGrounded) // if the player is on the ground when starting flying then jump up a bit before starting flying
        {
            Vector3 endPoint = transform.position + new Vector3(0, startJumpheight, 0);
            Vector3 startPoint = transform.position;
            for (float counter = 0; counter < 1; counter += Time.fixedDeltaTime * startJumpSpeed)
            {
                transform.position = Vector3.Lerp(startPoint, endPoint, jumpAnimationCurve.Evaluate(counter));
                yield return 0;
            }
        }
        isFlying = true;
    }

    //stops flying if the player collides with something
    private void OnCollisionEnter(Collision collision)
    {
        if (isFlying)
        {
            StopFlying();
        }
    }

    public override void JumpCheck()
    {
        if (!isFlying && playerScriptManager.activeCharacterScript == this) //the second part of this if statement used to fix a bug, not sure if it does anymore but cant hurt to have
        {
            base.JumpCheck();
        }
    }
}
