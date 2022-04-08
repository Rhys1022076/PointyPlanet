using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed;
    private bool isDashing = false;
    
    public ParticleSystem dashTrail;
    public ParticleSystem dashFx;
    
    private Rigidbody rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
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
