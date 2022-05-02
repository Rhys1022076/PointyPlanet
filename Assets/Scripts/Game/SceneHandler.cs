using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
	public Animator transition;
	public bool levelClear = false;

	public GameObject plainsTrigger;
	public GameObject forestTrigger;

	public GameObject pauseMenu;
	
	public GameObject[] enemies;
	public GameObject[] rabbits;

	private void Update()
	{
		//if (Input.GetKeyDown(KeyCode.Space))
		//{
		//	NextScene();
		//}

		if (GameManager.Instance.inDialogue == true) return;

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			pauseMenu.SetActive(true);
			GameManager.Instance.inDialogue = true;
			Time.timeScale = 0;
		}

		//if (Input.GetKeyDown(KeyCode.Backspace))
		//{
		//	MenuScene();
		//}

		if(SceneManager.GetActiveScene().name == "PricklyPlains" || SceneManager.GetActiveScene().name == "PinForest")
		{
			enemies = GameObject.FindGameObjectsWithTag("Enemy");
			rabbits = GameObject.FindGameObjectsWithTag("Rabbit");
			if (enemies.Length == 0 && rabbits.Length == 0)
			{
				levelClear = true;
				NextScene();
				//Debug.Log("You killed all enemies");
			}
		}	
	}

	public void NextScene()
	{
        //StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        if (levelClear)
        {
			if (SceneManager.GetActiveScene().name == "PricklyPlains")
            {
				// load second thorntown scene
				LoadLevel(3);
            }
			
			if (SceneManager.GetActiveScene().name == "PinForest")
			{
				// load thorntown finale scene
				//LoadLevel(x);
			}

		}

		if (SceneManager.GetActiveScene().name == "Menu")
		{
			// load Thorntown intro
			StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
		}

		if (SceneManager.GetActiveScene().name == "TTb4PP")
		{
			// load Prickly Plains
			StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
		}

		if (SceneManager.GetActiveScene().name == "TTb4PF")
		{
			// load Pin Forest
			StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
		}
	}

	public void ResumeGame()
	{
		pauseMenu.SetActive(false);
		GameManager.Instance.inDialogue = false;
		Time.timeScale = 1;
	}

	public void ReloadScene()
	{
		StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
	}

	public void MenuScene()
	{
		Time.timeScale = 1;
		StartCoroutine(LoadLevel(0));
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	IEnumerator LoadLevel(int levelIndex)
	{
		//animation
		transition.SetTrigger("Start");

		//wait
		yield return new WaitForSeconds(2);

		//load scene
		SceneManager.LoadScene(levelIndex);
	}
}
