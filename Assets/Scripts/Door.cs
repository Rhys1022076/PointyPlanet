using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    //The door object must have a collider set to “isTrigger” in the inspector


    //reference to the player script to check the player lockPickSkill.
    //PlayerControllerThatLevelsUp must have a int variable called ”currentLockPickSkill”

    private PlayerController playerController;

    public int GateDifficulty = 1;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<PlayerController>())
        {
            playerController = other.gameObject.GetComponent<PlayerController>();
            //PlayerControllerThatLevelsUp must have a int variable called ”currentLockPickSkill”
            CheckCurrentLevel();

        }

    }


    //PlayerControllerThatLevelsUp must have a int variable called ”currentLockPickSkill”
    private void CheckCurrentLevel()
    {
 
        if (playerController.level >= GateDifficulty)
        {
            Destroy(gameObject);
        }
        else if (playerController.level < GateDifficulty)
        {
            print("you are not a high enough level");
        }
    }

}
