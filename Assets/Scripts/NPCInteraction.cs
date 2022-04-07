using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    private GameObject trigNpc;
    private bool triggering;
    public GameObject DialogueFlowChart;
    public bool hasTalked;

    private GameObject talkPrompt;

    private void Start()
    {
        talkPrompt = transform.Find("TalkPrompt").gameObject;
        hasTalked = false;
    }

    private void Update()
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            triggering = true;
            trigNpc = other.gameObject;

            if (hasTalked) return;

            if (Input.GetMouseButtonDown(1))
            {
                DialogueFlowChart.SetActive(true);
                hasTalked = true;
            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (hasTalked) return;

        if (other.tag == "Player" && Input.GetMouseButtonDown(1))
        {
            DialogueFlowChart.SetActive(true);
            hasTalked = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            triggering = false;
            trigNpc = null;
        }
    }



}
