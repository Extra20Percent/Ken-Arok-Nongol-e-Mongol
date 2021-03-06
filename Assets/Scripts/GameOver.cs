using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public Text wavesText;

	void OnEnable()
	{
		wavesText.text = PlayerStats.wavesCount.ToString ();
	}

	public void Retry()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public void Menu()
	{
		SceneManager.LoadScene (1);
	}
}
