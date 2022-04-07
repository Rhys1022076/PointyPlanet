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
    public Transform player;
    public float turnSpeed = 10f;

    void Start()
    {
        patrol = GetComponent<Patrol>();
        bulletTime = GetComponent<BulletTime>();
    }

	private void Update()
	{
		if (playerInRange)
		{
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), Time.deltaTime * turnSpeed);
        }
	}

	void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("boink");
            StartCoroutine(Explode());
        }
    }

	public void OnTriggerStay(Collider other)
	{
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

	IEnumerator Explode()
    {
        patrol.StopAgent();
        bulletTime.StopShooting();
        Destroy(model);
        Destroy(col);
        explode.Play();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}