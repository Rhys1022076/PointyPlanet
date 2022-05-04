/*
 *  Author: ariel oliveira [o.arielg@gmail.com]
 */

using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;

    #region Singleton
    private static PlayerStats instance;
    public static PlayerStats Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<PlayerStats>();
            return instance;
        }
    }
    #endregion

    [SerializeField]
    private float health;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float maxTotalHealth;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }

    Animator anim;
    SceneHandler sceneHandler;

    private bool iFrames = false;
    private bool dead = false;

	private void Start()
	{
        anim = GetComponent<Animator>();
        sceneHandler = FindObjectOfType<SceneHandler>();
        dead = false;
	}

	private void Update()
	{
		if(health <= 0 && !dead)
		{
            Death();
            dead = true;
		}
	}

	public void Heal(float health)
    {
        this.health += health;
        ClampHealth();
    }

    public void TakeDamage(float dmg)
    {
        if (!iFrames)
        {
            Debug.Log("taking damage");

            if (health != 1)
            {
                anim.SetTrigger("Hurt");
            }

            health -= dmg;
            ClampHealth();
            StartCoroutine(Invincible());
        }
    }

    IEnumerator Invincible()
    {
        iFrames = true;
        yield return new WaitForSeconds(1f);
        iFrames = false;
        Debug.Log("no iframes");
    }

    public void AddHealth()
    {
        if (maxHealth < maxTotalHealth)
        {
            maxHealth += 1;
            health = maxHealth;

            if (onHealthChangedCallback != null)
                onHealthChangedCallback.Invoke();
        }   
    }

    public void Death()
	{
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Player/Death", gameObject.GetComponent<Transform>().position);
        StartCoroutine(DeathSequence());
	}

    IEnumerator DeathSequence()
	{
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(1);
        sceneHandler.ReloadScene();
	}

    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(1);
        }
    }
}
