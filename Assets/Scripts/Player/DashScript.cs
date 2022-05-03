using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    ThirdPersonMovement moveScript;

    private float dashSpeed = 40f;
    private float dashTime = 0.4f;
    public bool isDashing = false;
    private bool dashCharge = false;

    public ParticleSystem dashTrail;
    public ParticleSystem dashFx;

    private Animator anim;

    void Start()
    {
        moveScript = GetComponent<ThirdPersonMovement>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Disables dashing while in dialogue screens
        if (GameManager.Instance.inDialogue == true) return;

        if (Input.GetMouseButtonDown(0) && !dashCharge)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Player/Dash", gameObject.GetComponent<Transform>().position);
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;
        isDashing = true;
        dashCharge = true;
        anim.SetTrigger("Dashing");
        StartDashFX();
        
        while (Time.time < startTime + dashTime)
        {
            moveScript.controller.Move(transform.forward * dashSpeed * Time.deltaTime);

            yield return null;
        }

        isDashing = false;
        anim.SetTrigger("Dashed");
        StopDashFX();

        yield return new WaitForSeconds(2f);
        dashCharge = false;

        Debug.Log("Dash Charged");
    }

    void StartDashFX()
    {
        dashTrail.Play();
        dashFx.Play();
    }

    void StopDashFX()
    {
        dashTrail.Stop();
        dashFx.Stop();
    }
}
