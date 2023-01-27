using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SizeCharacter : Character
{
    [Header("Variables for this character script")]
    [SerializeField] float sizeChangeSpeed; //how fast the scale can be changed
    [SerializeField] float maxSize;     //the max scale size
    [SerializeField] float minSize;     //the min scale size
    private Coroutine coroutine;        //coroutine that runs as long as the special button/stick is being held
    [SerializeField] float startingMass;    //the starting mass of the player
    public override void SpecialButtonDown()
    {
        coroutine = StartCoroutine(ChangeSize());
    }

    public override void SpecialButtonUp()
    {
        StopCoroutine(coroutine);
    }

    //changes the players scale depending on the y value of the special stick
    IEnumerator ChangeSize()
    {
        while (true)
        {
            transform.localScale = transform.localScale * (specialStickVector.y * sizeChangeSpeed * Time.fixedDeltaTime + 1);    //changes size depending on the right stick
            //clamps the size
            if(transform.localScale.y < minSize)
            {
                transform.localScale = Vector3.one * minSize;
            }
            else if (transform.localScale.y > maxSize)
            {
                transform.localScale = Vector3.one * maxSize;
            }
            playerRb.mass = startingMass * transform.localScale.y;  //change the mass of the player depending on the scale
            yield return 0;
        }
    }
}