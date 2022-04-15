using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject model;

    [SerializeField]
    private Collider col;

    [SerializeField]
    private ParticleSystem explode;

    Patrol patrol;
    BulletTime bulletTime;

    private bool playerInRange = false;
    private Transform player;
    public float turnSpeed = 10f;

    void Start()
    {
        patrol = GetComponent<Patrol>();
        bulletTime = GetComponent<BulletTime>();
        player = GameObject.FindWithTag("Player").transform;
    }

	private void Update()
	{
		if (playerInRange)
		{
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), Time.deltaTime * turnSpeed);
        }
	}

    public void Boink()
    {
        Debug.Log("boink");
        StartCoroutine(Explode());
    }

    public void OnTriggerStay(Collider other)
	{
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    public IEnumerator Explode()
    {
        if(bulletTime != null)
        {
            if(bulletTime.IsInvoking("Shoot"))
            {
                bulletTime.StopShooting();
            }
        }
       

        if (patrol.destPoint != 0)
        {
            patrol.StopAgent();
        }

        Destroy(model);
        Destroy(col);
        explode.Play();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}