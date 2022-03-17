using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Tells the robot to aim at player character
/// </summary>
public class Aim : MonoBehaviour
{
    //Transform property for what you want to look at 
    public Transform target;
    //Defines rate at which our boy turns
    public float turnSpeed = 5f;
   
    // Update is called once per frame
    void Update()
    {
        //If there is a target, rotate to face target smoothly at turnSpeed
        if (target != null)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), Time.deltaTime*turnSpeed); 
        } 
    }

    //Sets new target when target enters (see in triggerzone script)
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
    
    //Stop targetting when there is no target (determined by triggerzone script)
    public void RemoveTarget()
    {
        target = null;
    }
}
