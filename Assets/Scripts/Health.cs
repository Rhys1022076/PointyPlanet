using UnityEngine;
using UnityEngine.Events;

//This script component will give health behavior to any object it is applied to. 
//Use the inspector to set the object starting health. 
//Call the TakeDamage function to take damage from the health.
//When the object dies it will call the objectHasDied Event.
//Use the inspector to have this event call other function on other scripts. 

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth; 
    public UnityEvent objectHasDied;



    public void TakeDamage(int DamageToTake)
    {
        health -= DamageToTake;
        //Sets minimum health to 0 & maximum HP to maxHealthvalue
        health = Mathf.Clamp(health, 0, maxHealth); 
        if (health <= 0)
        {
            objectHasDied.Invoke();
            Destroy(this.gameObject);

        }
    }

}
