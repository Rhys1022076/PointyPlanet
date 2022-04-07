using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed;
    private Rigidbody rb;
    private bool isDashing = false;
    public ParticleSystem dashTrail;
    public ParticleSystem dashFx;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
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
        isDashing = true;
        rb.AddForce(transform.forward * dashSpeed, ForceMode.Impulse);
        StartDashFX();
        yield return new WaitForSeconds(0.3f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        StopDashFX();
        yield return new WaitForSeconds(2f);
        isDashing = false;
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
