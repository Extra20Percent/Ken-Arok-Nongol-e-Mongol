﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryScript : MonoBehaviour {

	public void EndStory()
	{
		SceneManager.LoadScene (1);
	}
}
