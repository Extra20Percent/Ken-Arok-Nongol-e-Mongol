using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public GameObject ui;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
			{
				Toggle();
			}
	}

	public void Toggle()
	{
		ui.SetActive (!ui.activeSelf);

		if (ui.activeSelf) {
			Time.timeScale = 0f;
		} else {
			Time.timeScale = 1f;
		}
	}

	public void Retry()
	{
		Toggle ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		Time.timeScale = 1f;
	}

	public void Menu()
	{
		SceneManager.LoadScene (1);
		Time.timeScale = 1f;
	}
}
