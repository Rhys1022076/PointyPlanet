using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem explode;

    private Animator anim;

    BulletTime bulletTime;

    private bool playerInRange = false;

    public Transform player;

    public float turnSpeed = 10f;


    void Start()
    {
        bulletTime = GetComponent<BulletTime>();
        anim = GetComponent<Animator>();
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
        StartCoroutine(DeathSequence());
    }

    IEnumerator DeathSequence()
    {
        bulletTime.StopShooting();
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(2f);
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
