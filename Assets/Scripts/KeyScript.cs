using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyScript : MonoBehaviour
{
    public int xpValue = 1;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().GainXP(xpValue);
            Destroy(this.gameObject);
        }


    }
}