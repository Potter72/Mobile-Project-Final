using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBoots : CharacterEquipmentBase
{
    //class that contains information about equipment and inherhits from equipment base class
    //maybe should have done this with scriptable objects but this is fine

    public string equipmentName;    //name displayed on the UI
    public override float ModifyMoveValue(Character character)
    {
        return 0.5f;    //1 is default value
    }

    public override float ModifyJumpValue(Character character)
    {
        return 2f;    //1 is default value
    }
    public override string EquipmentName()
    {
        return equipmentName;
    }
}
