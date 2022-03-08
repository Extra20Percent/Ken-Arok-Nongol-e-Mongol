using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public static int Gold;
	public int startGold = 300;
	public static int Lifes;
	public int startLifes = 20;
	public static int wavesCount;

	void Start()
	{
		Gold = startGold;
		Lifes = startLifes;

		wavesCount = 0;
	}
}
