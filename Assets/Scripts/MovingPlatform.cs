using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float speed = 0.8f;          //the movement speed
    private Vector3 startingPosition;   //the start position
    private Vector3 direction;
    [SerializeField] GameObject endPoint;         //the end position
    [SerializeField] AnimationCurve moveCurve;    //the curve by which the platform will move

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;  //sets the starting position
        if (endPoint)
        {
            direction = endPoint.transform.position - transform.position;   //gets the direction to the end point 
        }
    }
    void FixedUpdate()
    {
        if (direction != Vector3.zero && speed != 0)
        {   
            //moves the gameobject based on the move curve and speed and in relation to the timescale
            transform.position = Vector3.Lerp(startingPosition, startingPosition + direction, moveCurve.Evaluate(Mathf.PingPong(Time.time * speed, 1)));
        }
    }
}
