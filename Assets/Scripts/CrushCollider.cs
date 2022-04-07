using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushCollider : MonoBehaviour
{

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
        }
    }
}
