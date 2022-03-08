using UnityEngine;

public class Shop : MonoBehaviour {

	public TowerBlueprint standardTower;
	public TowerBlueprint TowerB;
	public TowerBlueprint TowerC;
	public static bool chooseA;
	public static bool chooseB;
	public static bool chooseC;

	BuildManager buildManager;

	void Start()
	{
		buildManager = BuildManager.instance;
		chooseA = false;
		chooseB = false;
		chooseC = false;
	}

	public void SelectTower()
	{
		chooseA = true;
		chooseB = false;
		chooseC = false;
		buildManager.SelectTowerToBuild (standardTower);
	}

	public void SelectTowerB()
	{
		chooseA = false;
		chooseB = true;
		chooseC = false;
		buildManager.SelectTowerToBuild (TowerB);
	}

	public void SelectTowerC()
	{
		chooseA = false;
		chooseB = false;
		chooseC = true;
		buildManager.SelectTowerToBuild (TowerC);
	}
}
