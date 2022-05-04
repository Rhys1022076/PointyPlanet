using UnityEngine;
using System.Collections;

public class BossStats : MonoBehaviour
{
    [SerializeField]
    private float health;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float maxTotalHealth;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }

    private bool iFrames = false;
    private bool enraged = false;

    Boss bossScript;
    BulletTime bulletTime;
    
    Animator anim;
    //SceneHandler sceneHandler;

	private void Start()
	{
        anim = GetComponent<Animator>();
        //sceneHandler = FindObjectOfType<SceneHandler>();
        bossScript = GetComponent<Boss>();
        bulletTime = GetComponent<BulletTime>();
	}

	private void Update()
	{
        if(health <= 0)
		{
            StopAllCoroutines();
            enraged = false;
            anim.SetBool("Enraged", false);
            iFrames = true;
            Death();
		}

        if (enraged)
        {
            StartCoroutine(RestartShooting());
        }
	}

    IEnumerator RestartShooting()
    {
        bulletTime.StopShooting();
        yield return new WaitForSeconds(1.5f);
        bulletTime.StartShooting();
        enraged = false;
        anim.SetBool("Enraged", false);
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
                enraged = true;
                anim.SetBool("Enraged", true);
            }

            health -= dmg;
            ClampHealth();
            StartCoroutine(Invincible());
        }
    }

    IEnumerator Invincible()
    {
        iFrames = true;
        yield return new WaitForSeconds(2f);
        iFrames = false;
        Debug.Log("no iframes");
    }

    public void Death()
	{
        bossScript.Boink();
	}

    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
    }
}
