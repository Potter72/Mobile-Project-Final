using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerScriptManager : MonoBehaviour
{
    private PlayerInputActions playerInput; //the player input action map through which the button inputs are handled
    [Header("References to gameobjects/scripts")]
    public GameObject currentSpecialButtonGO;
    public GameObject specialStickPrefab;
    public GameObject specialButtonPrefab;
    public FeetTrigger feetScript;
    public CharacterInput characterInputScript;
    public EquipmentController equipmentControllerScript;
    [SerializeField] Image[] characterButtonImages;
    public enum CharacterType { Size, Time, Jetpack };
    private GameObject tempNewButton;
    public CharacterType activeCharacter;  //the default character type is Size but to call the ChangeCharacter function and set it to Size the activeCharacter needs to be something other than Sized
    public Character activeCharacterScript;
    public InputAction sizeCharacterSwitch;
    public InputAction timeCharacterSwitch;
    public InputAction jetpackCharacterSwitch;
    public Character[] characterScripts;        //list of the character scripts, couldve have done some stuff with dictionaries but this works fine

    [SerializeField] Color[] characterButtonSelectedColours;
    [SerializeField] Color[] characterButtonOriginalColours;

    //cooldown so that you cant switch character too fast
    // also fixes a very weird bug multiple character scripts(or maybe just jumping coroutines?) where active at the same time even if the unity inspector said they werent
    [SerializeField] float changeCharacterCooldown; 
    private bool canChangeCharacter = true;

    private void OnEnable()
    {
        playerInput = new PlayerInputActions();
        playerInput.Enable();
        //Size
        sizeCharacterSwitch = playerInput.Player.SwitchCharacter1;
        sizeCharacterSwitch.Enable();
        sizeCharacterSwitch.performed += ChangeSizeCharacter;
        //Time
        timeCharacterSwitch = playerInput.Player.SwitchCharacter2;
        timeCharacterSwitch.Enable();
        timeCharacterSwitch.performed += ChangeTimeCharacter;
        //Jetpack/Flying
        jetpackCharacterSwitch = playerInput.Player.SwitchCharacter3;
        jetpackCharacterSwitch.Enable();
        jetpackCharacterSwitch.performed += ChangeJetpackCharacter;

    }

    private void OnDisable()
    {
        playerInput.Disable();
        //Size
        sizeCharacterSwitch.Disable();
        sizeCharacterSwitch.performed -= ChangeSizeCharacter;
        //Time
        timeCharacterSwitch.Disable();
        timeCharacterSwitch.performed -= ChangeTimeCharacter;
        //Jetpack
        jetpackCharacterSwitch.Disable();
        jetpackCharacterSwitch.performed -= ChangeJetpackCharacter;
    }

    private void Awake()
    {
        activeCharacter = CharacterType.Time;
        ChangeCharacter(CharacterType.Size);
    }
    public void ChangeSizeCharacter(InputAction.CallbackContext context)
    {
        ChangeCharacter(CharacterType.Size);    
    }

    public void ChangeTimeCharacter(InputAction.CallbackContext context)
    {
        ChangeCharacter(CharacterType.Time);
    }    
    
    public void ChangeJetpackCharacter(InputAction.CallbackContext context)
    {
        ChangeCharacter(CharacterType.Jetpack);
    }

    private void ChangeCharacter(CharacterType type)
    {
        if(type != activeCharacter && canChangeCharacter)   //if the active character isnt the one being changed to
        {
            //spawns the special button gameobject for the according character type
            switch (type)
            {
                case CharacterType.Size:
                    tempNewButton = Instantiate(specialStickPrefab, currentSpecialButtonGO.transform.parent);
                    break;
                case CharacterType.Time:
                    tempNewButton = Instantiate(specialButtonPrefab, currentSpecialButtonGO.transform.parent);
                    break;
                case CharacterType.Jetpack:
                    tempNewButton = Instantiate(specialButtonPrefab, currentSpecialButtonGO.transform.parent);
                    break;
            }
            if(tempNewButton != null) tempNewButton.GetComponent<RectTransform>().position = currentSpecialButtonGO.GetComponent<RectTransform>().position; //places the new special button
            Destroy(currentSpecialButtonGO);    //destroys the old special button
            currentSpecialButtonGO = tempNewButton;

            //variables that carry over between characters
            int oldJumpCharges;
            int oldHealth;
            int oldMaxHealth;

            if (activeCharacterScript)
            {
                oldJumpCharges = activeCharacterScript.jumpCharges;
                oldHealth = activeCharacterScript.healthValue;
                oldMaxHealth = activeCharacterScript.maxHealth;
            }
            else
            {
                //default values
                oldJumpCharges = 2;
                oldHealth = 10;
                oldMaxHealth = 10;
            }

            //actives the specified character script and disables the others, also changes the colour of the button for the selected character to show its selected
            switch (type)
            {
                case CharacterType.Size:
                    activeCharacter = CharacterType.Size;
                    characterScripts[0].enabled = true;
                    characterScripts[1].enabled = false;
                    characterScripts[2].enabled = false;
                    activeCharacterScript = characterScripts[0];
                    //setting the selected button colour
                    ChangeSelectedButtonColour(0);
                    break;

                case CharacterType.Time:
                    activeCharacter = CharacterType.Time;
                    characterScripts[0].enabled = false;
                    characterScripts[1].enabled = true;
                    characterScripts[2].enabled = false;
                    activeCharacterScript = characterScripts[1];
                    //setting the selected button colour
                    ChangeSelectedButtonColour(1);
                    break;

                case CharacterType.Jetpack:
                    activeCharacter = CharacterType.Jetpack;
                    characterScripts[0].enabled = false;
                    characterScripts[1].enabled = false;
                    characterScripts[2].enabled = true;
                    activeCharacterScript = characterScripts[2];
                    //setting the selected button colour
                    ChangeSelectedButtonColour(2);
                    break;

            }

            characterInputScript.currentCharacterScript = activeCharacterScript;
            equipmentControllerScript.currentCharacterScript = activeCharacterScript;
            equipmentControllerScript.LoadEquipment();  //loads the currenttly equipped equipment to the new character script
            feetScript.playerScript = activeCharacterScript;
            
            //keeps some variables from the previous character script
            activeCharacterScript.jumpCharges = oldJumpCharges;
            activeCharacterScript.healthValue = oldHealth;
            activeCharacterScript.maxHealth = oldMaxHealth;

            canChangeCharacter = false;
            StartCoroutine(ChangeCharacterCooldown());  //cooldown so you cant change characters too fast
        }
    }

    //changes the colour of the selected character button and resets the colour of the other character swithcing buttons
    private void ChangeSelectedButtonColour(int buttonIndex)
    {
        for (int i = 0; i < characterButtonImages.Length; i++)
        {
            if(!(i == buttonIndex))
            {
                characterButtonImages[i].color = characterButtonOriginalColours[i];
            }
        }
        characterButtonImages[buttonIndex].color = characterButtonSelectedColours[buttonIndex];
    }

    IEnumerator ChangeCharacterCooldown()
    {
        yield return new WaitForSecondsRealtime(changeCharacterCooldown);
        canChangeCharacter = true;
    }
}
