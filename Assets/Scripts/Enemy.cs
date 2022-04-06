using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject model;

    [SerializeField]
    private ParticleSystem explode;
    
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("boink");
            StartCoroutine(Explode());
        }
    }

    IEnumerator Explode()
    {
        Destroy(model);
        explode.Play();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}