using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    ThirdPersonMovement moveScript;

    private float dashSpeed = 40f;
    private float dashTime = 0.4f;
    private bool isDashing = false;

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

        if (Input.GetMouseButtonDown(0) && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;
        isDashing = true;
        anim.SetTrigger("Dashing");
        StartDashFX();
        
        while (Time.time < startTime + dashTime)
        {
            moveScript.controller.Move(transform.forward * dashSpeed * Time.deltaTime);

            yield return null;
        }
        
        anim.SetTrigger("Dashed");
        StopDashFX();

        yield return new WaitForSeconds(2f);
        isDashing = false;

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
