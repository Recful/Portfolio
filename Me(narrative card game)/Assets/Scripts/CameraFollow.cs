using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;
    public float smoothBackSpeed = 0.05f;
    public Vector3 offset;
    private Vector3 camPosInitial;
    private Vector3 camPosStop;
    private Vector3 tempPos;

    void Start()
    {
        camPosInitial = transform.position;
        camPosStop = new Vector3(30.5f, 0f, -1f);
        
    }

    void FixedUpdate()
    {
        
        tempPos = transform.position;
        
        //cam stick on the initial position
        if(target.position.x > -8.6 && target.position.x < 8.850573)
        {
            transform.position = Vector3.Lerp(tempPos, camPosInitial, smoothBackSpeed);
        }
        //cam focus on the player
        if(target.position.x > 8.850573)
        {
            Vector3 desiredPosition = new Vector3(target.position.x + offset.x, camPosInitial.y, target.position.z +offset.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }

        //cam stick on the stop position
        if(target.position.x > 30 && target.position.x < 40)
        {
            
            transform.position = Vector3.Lerp(tempPos, camPosStop, smoothBackSpeed);
        }

    }

}
