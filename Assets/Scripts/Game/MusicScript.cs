using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicScript : MonoBehaviour
{
    private static FMOD.Studio.EventInstance Music;

    Scene scene;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

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
            ProgressMusic(2.5f);
        }
    }
}
