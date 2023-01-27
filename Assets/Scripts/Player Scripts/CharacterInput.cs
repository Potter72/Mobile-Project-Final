using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInput : MonoBehaviour
{
    [Header("Inputs")]
    private PlayerInputActions playerInput; //the player input action map
    private InputAction jumpAction;
    public InputAction leftStick;       //movement stick
    public InputAction specialButton;   //the special button for Time and Flight character
    public InputAction specialStick;    //the special button/stick for the Scale/Size character

    public Character currentCharacterScript;    //current character script

    private void OnEnable()
    {
        //getting inputs and subscibing
        playerInput = new PlayerInputActions();
        playerInput.Enable();
        jumpAction = playerInput.Player.Jump;
        leftStick = playerInput.Player.Move;
        specialButton = playerInput.Player.SpecialButton;
        specialStick = playerInput.Player.SpecialStick;
        specialStick.Enable();
        jumpAction.Enable();
        leftStick.Enable();
        specialButton.Enable();
        jumpAction.performed += CallJumpCheck;
        jumpAction.canceled += CallStopJump;
        specialButton.performed += CallSpecialButtonDownInput;
        specialButton.canceled += CallSpecialButtonUpInput;

    }

    private void OnDisable()
    {
        //unsubscibing from the input events
        playerInput.Disable();
        jumpAction.Disable();
        leftStick.Disable();
        specialButton.Disable();
        specialStick.Disable();
        jumpAction.performed -= CallJumpCheck;
        jumpAction.canceled -= CallStopJump;
        specialButton.performed -= CallSpecialButtonDownInput;
        specialButton.canceled -= CallSpecialButtonUpInput;
    }

    private void Update()
    {
        //updates joystick input for the current character script if the player isnt getting knocked back
        if (currentCharacterScript && !currentCharacterScript.isGettingKnockedbacked)
        {
            currentCharacterScript.moveVectorData = leftStick.ReadValue<Vector2>();
            currentCharacterScript.specialStickVector = specialStick.ReadValue<Vector2>();
        }
        //if player is getting knocked back then set the move variables to 0 
        //knockback was being really weird when it came to swithcing characters and isnt really necessary so this isnt being used at the moment
        else if (currentCharacterScript) 
        {
            currentCharacterScript.moveVectorData = Vector2.zero;
            currentCharacterScript.specialStickVector = Vector2.zero;
        }
    }

    public virtual void CallJumpCheck(InputAction.CallbackContext context)
    {
        //if the player is not getting knockbacked then jump
        if(!currentCharacterScript.isGettingKnockedbacked)  
        currentCharacterScript.JumpCheck();
    }
    //call the stop jump function on the character
    public void CallStopJump(InputAction.CallbackContext context)
    {
        currentCharacterScript.isHoldingJump = false;
    }
    //call the stop special button down function on the character
    private void CallSpecialButtonDownInput(InputAction.CallbackContext context)
    {
        if (!currentCharacterScript.isGettingKnockedbacked)
        currentCharacterScript.SpecialButtonDown();
    }
    //call the stop special button up function on the character
    private void CallSpecialButtonUpInput(InputAction.CallbackContext context)
    {
        currentCharacterScript.SpecialButtonUp();
    }
}
