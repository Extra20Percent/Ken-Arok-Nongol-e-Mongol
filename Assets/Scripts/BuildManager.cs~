using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake()
	{
		if (instance != null) {
			Debug.LogError ("More than one Build Manager!");
			return;
		}
		instance = this;
	}

	public GameObject buildEffect;
	public GameObject sellEffect;

	private TowerBlueprint towerToBuild;
	private Node selectedTower;
	public TowerUI towerUI;

	public bool CanBuild{ get { return towerToBuild != null; } }
	public bool HasGold { get { return PlayerStats.Gold >= towerToBuild.cost; } }
		

	public void SelectTower (Node node)
	{
		if (selectedTower == node) {
			DeselectNode ();
			return;
		}
		selectedTower = node;
		towerToBuild = null;

		towerUI.SetTarget (node);
	}

	public void DeselectNode()
	{
		selectedTower = null;
		towerUI.Hide ();
	}

	public void SelectTowerToBuild(TowerBlueprint tower)
	{
		towerToBuild = tower;
		DeselectNode ();
	}

	public TowerBlueprint GetTowerToBuild()
	{
		return towerToBuild;
	}
}
