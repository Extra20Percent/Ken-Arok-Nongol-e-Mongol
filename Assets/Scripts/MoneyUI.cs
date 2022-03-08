using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour {

	public Text goldText;

	void Update()
	{
		goldText.text = PlayerStats.Gold.ToString () + " Gold";
	}
}
