using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyAudio : MonoBehaviour {

	public static bool backgroundNeeded = true;
	public static DontDestroyAudio instance;

	void Awake()
	{
		if (instance != null) {
			Destroy (transform.gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (transform.gameObject);
		}
	}

	void Update()
	{
		if (!backgroundNeeded)
			Destroy (transform.gameObject);
	}
}
