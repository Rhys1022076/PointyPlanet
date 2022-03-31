using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float speed = 13f;

    
    // Update is called once per frame
    void Update()
    {
      transform.position += transform.forward * Time.deltaTime * speed; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
