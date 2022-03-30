using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    Vector3 input;


    // Update is called once per frame
    void Update()
    {
        //New WASD controls based on vectors for X & Z access. The 0 represents the Y axis which is unchanging.
        // GetAxisRaw allows for instant max movement rather than speed up, whereas pure GetAxis would be an acceleration.
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        //Will represent moving on any axis as a 1, prevents diagonals from being faster
        input = input.normalized;


        transform.position += Vector3.right * input.x * Time.deltaTime * moveSpeed;
        transform.position += Vector3.forward * input.z * Time.deltaTime * moveSpeed;
    }

}