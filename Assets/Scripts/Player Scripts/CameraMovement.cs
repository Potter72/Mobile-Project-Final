using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;       //the target for the camera (player)
    [SerializeField] float smoothSpeed = 0.2f;   //speed at which the camera follows the player
    [SerializeField] float velocityMultiplier = 8;  //how much the movevment of the target should impact the position of the camera, it will try to be in front of the target
    [SerializeField] float scaleZoomMultiplier = 0.6f;  //how much the scale of the target should impact the zoom of the camera
    public Vector3 offset;          //the camera offset
    private Vector3 startingOffset;
    private Vector3 oldTargetPosition;  
    private Vector3 newTargetPosition;
    private Vector3 targetMoved;    //vector of the distance the target has moved
    private float screenRatio;  //the ratio of the screen, good for mobile
    [SerializeField] float screenRatioMultiplier = 0.7f; //how much the ratio of the screen should matter

    private void Awake()
    {
        screenRatio = (float)Screen.width / (float)Screen.height;   //calculates the screen ratio
        startingOffset = offset;
    }

    void FixedUpdate()
    {
        //calculates the distance the target has moved
        newTargetPosition = target.transform.position;
        targetMoved = newTargetPosition - oldTargetPosition;
        oldTargetPosition = target.transform.position;

        targetMoved = new Vector3(targetMoved.x, targetMoved.y / screenRatio * screenRatioMultiplier, targetMoved.z);   //modifies the target moved

        Vector3 desiredPosition = target.transform.position + startingOffset * Mathf.Pow(target.transform.localScale.x, scaleZoomMultiplier) + targetMoved * velocityMultiplier;    //Position the camera will try to go to
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);          //Position the camera will be at on the path to the desired position

        transform.position = smoothedPosition;  //sets the position
    }
}
