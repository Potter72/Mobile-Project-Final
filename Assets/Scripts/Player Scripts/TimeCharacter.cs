using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCharacter : Character
{
    [Header("Variables for this character script")]
    [SerializeField] float timeSlowScale;
    private bool backAndForth = false;
    public float defaultFixedDeltaTime; //accessed by the game manager when loading the scene
    private bool doOnce = false;
    [SerializeField] float slowedTimeConstantYForce;
    public override void SpecialButtonDown()
    {
        if (!backAndForth)  //this will always be true first
        {
            if (!doOnce) 
            { 
                defaultFixedDeltaTime = Time.fixedDeltaTime;    //movement of the player is dependent on fixedDeltatime and as such will stay the same when time is slowed
                doOnce = true; 
            }
            Time.timeScale = timeSlowScale;
            GetComponent<ConstantForce>().force = new Vector3(0, slowedTimeConstantYForce, 0);  //adds a constant downwards force to the play so that it wall fall at the same speed as when the time was not slowed
            backAndForth = !backAndForth;
        }
        else
        {
            Time.timeScale = 1;
            GetComponent<ConstantForce>().force = new Vector3(0, 0, 0);
            backAndForth = !backAndForth;
        }
        if(defaultFixedDeltaTime != 0) Time.fixedDeltaTime = defaultFixedDeltaTime * Time.timeScale;
    }
}
