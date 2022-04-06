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

    void Start()
    {
        patrol = GetComponent<Patrol>();
        bulletTime = GetComponent<BulletTime>();
    }

	private void Update()
	{
		if (playerInRange)
		{
            transform.LookAt(player);
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