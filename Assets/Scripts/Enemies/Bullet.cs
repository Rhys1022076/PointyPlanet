using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    private float timer;

    Prickidna wildlifeScript;

	void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        timer += 1f * Time.deltaTime;

        if(timer >= 4f)
        {
            Destroy(gameObject);
        }
    }

    /*void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Wildlife")
        {
            wildlifeScript = hit.gameObject.GetComponent<Prickidna>();
            wildlifeScript.Crossfire();
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        
        Destroy(gameObject);
    }
}