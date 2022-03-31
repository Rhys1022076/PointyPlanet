using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnCollisionStay(Collision collisionInfo)
    {
        foreach (ContactPoint contact in collisionInfo.contacts)
        {
            //Debug-draw all contact points and normals
            //Debug.DrawRay(contact.point, contact.normal * 10, Color.white);
            Destroy(gameObject);
        }
    }
}