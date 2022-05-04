using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6;
    public float turnSmoothTime = 0.1f;

    public Transform cam;
    public Camera cameraRay;

    private Animator anim;
    Enemy enemyScript;
    PlayerStats playerStats;
    DashScript dashScript;
    Generator generator;
    BossStats bossStats;

    //Jump Stuff
    Vector3 velocity;
    public float gravity = -9.8f;
    public Transform groundCheck;
    public float groundDist;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 0;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        playerStats = GetComponent <PlayerStats>();
        dashScript = GetComponent <DashScript>();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Rabbit" || hit.gameObject.tag == "Enemy")
        {
            enemyScript = hit.gameObject.GetComponent<Enemy>();
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Enemies/Explosion", gameObject.GetComponent<Transform>().position);
            enemyScript.Boink();
        }

        if (hit.gameObject.tag == "Pickup")
        {
            Debug.Log("Pickup");
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Player/Heal", gameObject.GetComponent<Transform>().position);
            playerStats.Heal(1);
            Destroy(hit.gameObject);
        }

        if (hit.gameObject.tag == "Crusher" || hit.gameObject.tag == "Blade")
        {
            Debug.Log(hit.gameObject);
            playerStats.TakeDamage(1);
        }

        if (hit.gameObject.tag == "Generator")
        {
            generator = hit.gameObject.GetComponent<Generator>();
            generator.DestroyGenerator();
        }

        if (hit.gameObject.tag == "Boss")
        {
            bossStats = hit.gameObject.GetComponent<BossStats>();
            bossStats.TakeDamage(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BossBlade"))
        {
            Debug.Log(other);
            playerStats.TakeDamage(1);
        }
    }

    void Update()
    {
        if (GameManager.Instance.inDialogue == true)
        {
            anim.SetBool("isMoving", false);
            return;
        }

		if (dashScript.isDashing)
		{
            RotateFromMouseVector();
            anim.SetBool("isMoving", false);
            return;
        }

        anim.SetBool("isMoving", false);

        RotateFromMouseVector();
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v).normalized;

        if (dir.magnitude >= 0.1f)
        {
            controller.Move(dir.normalized * speed * Time.deltaTime);
            anim.SetBool("isMoving", true);
        }

        //Jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void RotateFromMouseVector()
    {
        Ray ray = cameraRay.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }
}
