using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenScript : MonoBehaviour {

	public void PressAnywhere()
	{
		SceneManager.LoadScene (1);
	}
}
