using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static bool gameEnd;

	public GameObject gameOverUI;
	public GameObject winScreenUI;

	public AudioSource dialogueWin;

	void Start()
	{
		gameEnd = false;
	}

	void Update () {
		if (gameEnd) {
			return;
		}

/* Temporary exit for testing. Hapus waktu release.		
 * if (Input.GetKeyDown ("e")) {
	EndGame ();
	} */

		if (PlayerStats.Lifes <= 0) {
			EndGame ();
		}
	}

	void EndGame()
	{
		gameEnd = true;
		gameOverUI.SetActive (true);
	}

	public void WinLevel()
	{
		gameEnd = true;
		winScreenUI.SetActive (true);
		dialogueWin.Play ();
	}
}
