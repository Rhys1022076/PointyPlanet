using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    private GameObject trigNpc;
    private bool triggering;
    public GameObject DialogueFlowChart;
    public GameObject talkPrompt;

  
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
   /* private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            trigNpc = other.gameObject;

            if (hasTalked) return;

            if (Input.GetMouseButtonDown(1))
            {
                DialogueFlowChart.SetActive(true);
            }

        }
    }
   */
    private void OnTriggerStay(Collider other)
    {

        if(GameManager.Instance.inDialogue == true) return;
        triggering = true;

        if (other.tag == "Player" && Input.GetMouseButtonDown(1))
        {
            DialogueFlowChart.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            //triggering = false;
            trigNpc = null;
        }
    }


}
