using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool inDialogue;


    // Singleton implentation
    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }


    public void EnableMovement()
    {
        // Used to enable movement & chat
        inDialogue = false;
        //Time.timeScale = 1f;
    }

    public void DisableMovement()
    {
        // Used to disable movement & chat
        inDialogue = true;
       // Time.timeScale = 0.00001f;
    }


}
