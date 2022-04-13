using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
	public Animator transition;
	
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			NextScene();
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			QuitGame();
		}

		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			MenuScene();
		}
	}

	public void NextScene()
	{
		StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
	}

	public void ReloadScene()
	{
		StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
	}

	public void MenuScene()
	{
		StartCoroutine(LoadLevel(0));
	}

	void QuitGame()
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
