using UnityEngine;
using UnityEngine.Events;

//Attach this script to an object that has a trigger collider.
//When another object enters the trigger collider this will call the trigger enter event 
//When another object exits the trigger collider this will call the trigger exit event 
//Make a copy of this script and change the tag to implement different reactions to different objects. 

//Automatically attaches a collider to the object if it doesn't already have the necessary collider
//[RequireComponent(typeof(Collider))]

public class PlayerEnterOrExitTriggerZoneEvent : MonoBehaviour
{
    //Creates the events for shooty shooty
    public UnityEvent triggerEnterEvent;
    public UnityEvent triggerExitEvent;

    //Creates the transform events for robot to aim
    public UnityEvent<Transform> onTransformEnterEvent;
    public UnityEvent<Transform> onTransformExitEvent;


    // OnValidate makes an update whenever something changes in the inspector. 
    // Sets the collider component attached to the object & makes that the trigger.
    //private void OnValidate()
    //{
    //    GetComponent<Collider>().isTrigger = true;   
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerEnterEvent.Invoke();
            onTransformEnterEvent.Invoke(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerExitEvent.Invoke();
            onTransformExitEvent.Invoke(other.transform);  
        }
    }
}
