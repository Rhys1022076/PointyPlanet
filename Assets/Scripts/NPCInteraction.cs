using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    private GameObject trigNpc;
    private bool triggering;

    private GameObject talkPrompt;

    private void Start()
    {
        talkPrompt = transform.Find("TalkPrompt").gameObject;
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
