using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPit : MonoBehaviour
{
    public int heal = 3;

    void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Collison");

        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Health>() == true)
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(-heal);
            }
        }

    }

}