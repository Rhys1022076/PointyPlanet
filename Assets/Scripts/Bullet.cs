using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float speed = 13f;
    private float timer;

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        timer += 1f * Time.deltaTime;

        if(timer >= 4f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}