using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCInteraction : MonoBehaviour
{
    private bool triggering = false;
    public GameObject DialogueFlowChart;
    public GameObject talkPrompt;
    public GameObject trigNPC;

    /*
    private void FixedUpdate()
    {
        if (triggering)
        {
            talkPrompt.SetActive(true);
        }
        else
        {
            talkPrompt.SetActive(false);
        }
    }
    */
    
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter Trigger");
        if (other.tag == "Player")
        {
            triggering = true;
        }
    }
   

    private void OnTriggerStay(Collider other)
        {

            if (GameManager.Instance.inDialogue == true) return;
           

            if (other.tag == "Player" && Input.GetMouseButtonDown(1))
            {
                DialogueFlowChart.SetActive(true);
            }
        }

    private void OnTriggerExit(Collider other)
        {
            Debug.Log("Exit Trigger");
            if (other.tag == "Player")
            {
                triggering = false;
            }
        }


    
}
