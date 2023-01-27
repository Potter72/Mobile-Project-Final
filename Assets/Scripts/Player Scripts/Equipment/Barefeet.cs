using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barefeet : CharacterEquipmentBase
{
    //barefeet uses the default values
    public string equipmentName;    //the name that will be displayed for the UI
    public override float ModifyMoveValue(Character character)
    {
        return 1f;    //1 is default value
    }

    public override float ModifyJumpValue(Character character)
    {
        return 1f;    //1 is default value
    }
    public override string EquipmentName()
    {
        return equipmentName;
    }
}
