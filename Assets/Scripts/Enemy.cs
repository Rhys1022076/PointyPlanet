using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject model;

    [SerializeField]
    private Collider col;

    [SerializeField]
    private ParticleSystem explode;

    Patrol patrol;

    void Start()
    {
        patrol = GetComponent<Patrol>();
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("boink");
            StartCoroutine(Explode());
        }
    }

    IEnumerator Explode()
    {
        patrol.StopAgent();
        Destroy(model);
        Destroy(col);
        explode.Play();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}