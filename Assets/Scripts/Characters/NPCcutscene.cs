using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcutscene : MonoBehaviour
{
    private GameObject trigNpc;
    private bool triggering;
    public GameObject DialogueFlowChart;
    public bool hasTalked;


    private void Start()
    {
        //talkPrompt = transform.Find("TalkPrompt").gameObject;
        hasTalked = false;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            trigNpc = other.gameObject;

            if (hasTalked) return;
            if (other.tag == "Player")
            {
                DialogueFlowChart.SetActive(true);
                hasTalked = true;
            }

        }

    }
}

