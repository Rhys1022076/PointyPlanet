using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prickidna : MonoBehaviour
{
    [SerializeField]
    public GameObject wildlife;

    Patrol patrol;

    public float turnSpeed = 10f;

    void Start()
    {
        patrol = GetComponent<Patrol>();
    }


    /*
    public void Crossfire()
    {
        Debug.Log("Nooo!");
            Destroy(gameObject);
   
    }
    */
}
