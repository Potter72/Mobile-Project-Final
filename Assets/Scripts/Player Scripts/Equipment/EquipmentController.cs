using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class EquipmentController : MonoBehaviour
{
    [SerializeField] GameObject[] equipmentGOs; //list of prefabs gameobjects containing the script for each equipment
    private GameObject currentEquipmentGO;      //the current equipped equipment gameobject
    [SerializeField] TextMeshProUGUI equippedText;  //the text saying whats equipped
    public Character currentCharacterScript;        //the currently active character script
    private CharacterEquipmentBase equipmentBase;   //the equipmentBase class that contains virtual fucntions for extracting the equipment modify data

    [Header("Inputs")]
    private PlayerInputActions playerInput;
    private InputAction changeEquipmentAction;  //input action the change equipment button is hooked up to
    private int equipmentIndex;                 //the index of the current equipment in the array of equipments
    private void OnEnable()
    {
        //doing input stuff
        playerInput = new PlayerInputActions();
        playerInput.Enable();
        changeEquipmentAction = playerInput.Player.SwitchEquipment;
        changeEquipmentAction.Enable();
        changeEquipmentAction.performed += CallChangeEquipment;
    }

    private void OnDisable()
    {
        //doing'nt said input stuff
        playerInput.Disable();
        changeEquipmentAction.Disable();
        changeEquipmentAction.performed -= CallChangeEquipment;
    }
    private void Start()
    {
        //sets the equipped item to a random item in the list of equipments
        equipmentIndex = Random.Range(0, equipmentGOs.Length);
        ChangeEquipment();
    }

    //changes the current equipment
    private void CallChangeEquipment(InputAction.CallbackContext context)
    {
        ChangeEquipment();
    }

    //changes the equipment to the next one in the array
    private void ChangeEquipment()
    {
        if (currentEquipmentGO) Destroy(currentEquipmentGO);
        equipmentIndex++;
        if (equipmentIndex > equipmentGOs.Length - 1) equipmentIndex = 0;
        currentEquipmentGO = Instantiate(equipmentGOs[equipmentIndex], transform);  //instantiates game object with the equipment code on it
        LoadEquipment();
    }

    //sets the equipment variebles in current character script to what the current equipment says the should be
    public void LoadEquipment()
    {
        if(currentEquipmentGO)
        {
            equipmentBase = currentEquipmentGO.GetComponent<CharacterEquipmentBase>();
            equipmentBase.activeCharacter = currentCharacterScript;
            currentCharacterScript.moveEquipmentMultiplier = equipmentBase.ModifyMoveValue(currentCharacterScript); //modifies the value in the current character script
            currentCharacterScript.jumpEquipmentMultiplier = equipmentBase.ModifyJumpValue(currentCharacterScript); //modifies the value in the current character script
            equippedText.text = equipmentBase.EquipmentName();
        }
    }
}
