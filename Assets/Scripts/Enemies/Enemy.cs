using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem explode;

    private Animator anim;

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
        anim = GetComponent<Animator>();
        Invoke(nameof(StartAttack), Random.Range(0, 1f));

    }

    private void StartAttack()
    {
        if (anim == null) return;

        anim.SetTrigger("Start");
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
        Destroy(gameObject);
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

    private void OnDestroy()
    {
        var clone = Instantiate(explode, transform.position, transform.rotation);
        Destroy(clone.gameObject, 2f);
    }
}