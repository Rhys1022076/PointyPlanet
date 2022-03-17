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


    

    public float xp = 0;	// Amount of XP the player has
    public float xpForNextLevel = 10;   //Xp needed to level up, the higher the level, the harder it gets. 
    public int level = 0;   // Level of the player

    // To level up you need to collect an amount of xp;
    // This starts at 10 xp
    // Each level you gain the xp required gets higher exponentially
    // The exponential growth is slowed by scaling it by 10%

    void SetXpForNextLevel()
    {
        xpForNextLevel = (10f + (level * level * 0.1f));
        Debug.Log("xpForNextLevel " + xpForNextLevel);
    }


    void LevelUp()
    {
        xp = 0f;
        level++;
        Debug.Log("level" + level);
        SetXpForNextLevel();

    }


    //a function to make the player gain the amount of Xp the you tell it. 
    public void GainXP(int xpToGain)
    {
        xp += xpToGain;
        Debug.Log("Gained " + xpToGain + " XP, Current Xp = " + xp + ", XP needed to reach next Level = " + xpForNextLevel);

        UpdateXp();
    }


    void UpdateXp()
    {
        //LevelUp when the appropriate conditions are met.
        if (xp >= xpForNextLevel)
        {
            LevelUp();
        }


    }
}