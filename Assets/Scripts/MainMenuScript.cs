using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	public void PlayGame()
	{
		SceneManager.LoadScene (2);
		DontDestroyAudio.backgroundNeeded = false;
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void Story()
	{
		SceneManager.LoadScene (3);
	}

	public void Credits()
	{
		SceneManager.LoadScene (4);
	}
}
