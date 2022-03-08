using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour {

	public GameObject ui;
	public Text upgradeCost;
	public Button upgradeButton;
	public Text sellAmount;
	private Node target;

	public void SetTarget(Node _target)
	{
		this.target = _target;

		transform.position = target.GetBuildPosition();

		if (!target.isUpgraded) {
			upgradeCost.text = target.towerBlueprint.upgradeCost + " Gold";
			upgradeButton.interactable = true;
		} else {
			upgradeCost.text = "MAXED";
			upgradeButton.interactable = false;
		}

		sellAmount.text = target.towerBlueprint.GetSellAmount () + " Gold";

		ui.SetActive (true);
	}

	public void Hide()
	{
		ui.SetActive (false);
	}

	public void Upgrade()
	{
		target.UpgradeTower ();
		BuildManager.instance.DeselectNode ();
	}

	public void Sell()
	{
		target.SellTower ();
		BuildManager.instance.DeselectNode ();
	}
}
