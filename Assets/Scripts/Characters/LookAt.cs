using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{

    //for Pinelope's jank model

    private bool isLooking;

    public float rotationSpeed;
    public Transform lookAtTarget; 

    public void StartLooking()
    {
        isLooking = true;
    }

    public void StopLooking()
    {
        isLooking = false; 
    }

    private void Update()
    {
        if(isLooking)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lookAtTarget.position - transform.position, Vector3.up), rotationSpeed);
        }
    }

}
