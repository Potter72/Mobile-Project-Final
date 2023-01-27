using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipmentBase : MonoBehaviour
{
    public Character activeCharacter;       //set by the character switching script

    public virtual float ModifyJumpValue(Character character)
    {
        return 1;   //standard value, shouldnt ever be achieved due to this function being overriden by inherited classes
    }
    public virtual float ModifyMoveValue(Character character)
    {
        return 1;   //standard value, shouldnt ever be achieved due to this function being overriden by inherited classes
    }
    public virtual string EquipmentName()
    {
        return "nothing equipped";  //standard value, shouldnt ever be achieved due to this function being overriden by inherited classes
    }

}
