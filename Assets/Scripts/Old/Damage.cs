using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Creates damage integer 
    public int damage = 2;
    // Makes an array of the targets of our destruction 
    public string[] objectTags;

    void OnCollisionEnter(Collision collision)
    {
        // Checks that the object collided with has appropriate tag
        bool hasHitTag = false;

        // Checks each tag. If the object has one of the specified tags. If it does not, no damage. If it does, see next part.
        foreach (var tag in objectTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                hasHitTag = true;
                break;
            }
        }

        // Deal damage to an object that had one of the tags checked for in above code. 
        if (hasHitTag)
        {
            if (collision.gameObject.GetComponent<Health>() == true)
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            }
        }

    }

}
