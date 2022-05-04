using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicScript : MonoBehaviour
{
    private static MusicScript current;
    private static FMOD.Studio.EventInstance Music;

    Scene scene;

    private GameObject boss;
    Boss bossScript;

    private void Awake()
    {
        if (current != null && current != this) Destroy(gameObject);
        else
        {
            current = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
       
        Music = FMODUnity.RuntimeManager.CreateInstance("event:/Soundtrack/Soundtrack");
        //Music.setParameterByName("Location", 4.5f);
        Music.start();
        Music.release();
    }

    public void ProgressMusic(float CurrentLevel)
	{
        Music.setParameterByName("Location", CurrentLevel);
	}

    void Update()
    {
        scene = SceneManager.GetActiveScene();
        print(scene.name);

        if (scene.name == "Menu")
		{
            ProgressMusic(4.5f); 
        }

        if (scene.name == "TTb4PP" || scene.name == "TTb4PF")
        {
            ProgressMusic(0.5f);
        }

        if (scene.name == "PricklyPlains")
        {
            ProgressMusic(1.5f);
        }

        if (scene.name == "PinForest")
        {
            boss = GameObject.FindGameObjectWithTag("Boss");
            bossScript = boss.GetComponent<Boss>();
            ProgressMusic(2.5f);

			if (bossScript.bossMusic)
			{
                ProgressMusic(3.5f);
			}
        }
    }
}
