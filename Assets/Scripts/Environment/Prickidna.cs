using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prickidna : MonoBehaviour
{
    [SerializeField]
    private GameObject model;

    Patrol patrol;

    public float turnSpeed = 10f;
    
    void Start()
    {
        patrol = GetComponent<Patrol>();
    }
}
