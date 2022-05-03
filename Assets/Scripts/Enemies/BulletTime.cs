using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletTime : MonoBehaviour
{
    // Determines rate of fire
    public float shootSpeed = 0.5f;

    // How far the bullet spawns away from the robot, to prevent suicide
    //public float bulletSpawnDistance = 0.5f;

    // Allows referral to bullet prefab in script
    public GameObject bullet;

    // Set a position for the bullet to spawn at using an empty gameobject
    public Transform bulletSpawn;
    public Transform bulletSpawnLeft;
    public Transform bulletSpawnRight;

    //Vector3 bulletSpawn;

    public void StartShooting()
    {
       // Starts the shooting method after 1 sec delay, before continuing to shoot at shootSpeed
       if (!IsInvoking("Shoot"))
       {
            InvokeRepeating("Shoot", 1f, shootSpeed); 
       }
    }

    public void StopShooting()
    {
        // Stops the shooting (wow)
        CancelInvoke("Shoot");
    }

    private void Shoot()
    {
        Debug.Log("Pew");
        // Creates the bullet at the position of the robot & at the same rotation as the robot

        if (bulletSpawn != null)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemies/Laser", gameObject.GetComponent<Transform>().position);
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);  
        }
        if (bulletSpawnLeft != null)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemies/Laser", gameObject.GetComponent<Transform>().position);
            Instantiate(bullet, bulletSpawnLeft.position, bulletSpawnLeft.rotation);  
        }
        if (bulletSpawnRight != null)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemies/Laser", gameObject.GetComponent<Transform>().position);
            Instantiate(bullet, bulletSpawnRight.position, bulletSpawnRight.rotation);  
        }
        
    }
}
