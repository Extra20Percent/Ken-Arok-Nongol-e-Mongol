using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public Vector3 positionOffset;
	public Color insufficientColor;

	[HideInInspector]
	public GameObject tower;
	[HideInInspector]
	public TowerBlueprint towerBlueprint;
	[HideInInspector]
	public bool isUpgraded = false;

	private Renderer rend;
	private Color startColor;

	BuildManager buildManager;

	void Start()
	{
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;

		buildManager = BuildManager.instance;
	}

	public Vector3 GetBuildPosition()
	{
		return transform.position + positionOffset;
	}

	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject ()) {
			return;
		}
			

		if (tower != null) {
			buildManager.SelectTower (this);
			return;
		}

		if (!buildManager.CanBuild) {
			return;
		}

		BuildTower(buildManager.GetTowerToBuild());
	}

	void BuildTower (TowerBlueprint blueprint)
	{
		if (PlayerStats.Gold < blueprint.cost) {
			Debug.Log ("Not enough gold!");
			return;
		}

		PlayerStats.Gold -= blueprint.cost;

		GameObject _tower = (GameObject)Instantiate (blueprint.prefab, GetBuildPosition(), Quaternion.identity);
		tower = _tower;

		towerBlueprint = blueprint;

		GameObject effect = (GameObject)Instantiate (buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
		Destroy (effect, 5f);
	}

	public void UpgradeTower()
	{
		if (PlayerStats.Gold < towerBlueprint.upgradeCost) {
			Debug.Log ("Not enough gold to upgrade!");
			return;
		}

		PlayerStats.Gold -= towerBlueprint.upgradeCost;

		Destroy (tower);

		GameObject _tower = (GameObject)Instantiate (towerBlueprint.upgradedPrefab, GetBuildPosition (), Quaternion.identity);
		tower = _tower;

		GameObject effect = (GameObject)Instantiate (buildManager.buildEffect, GetBuildPosition (), Quaternion.identity);
		Destroy (effect, 5f);

		isUpgraded = true;
	}

	public void SellTower()
	{
		PlayerStats.Gold += towerBlueprint.GetSellAmount ();

		GameObject effect = (GameObject)Instantiate (buildManager.sellEffect, GetBuildPosition (), Quaternion.identity);
		Destroy (effect, 5f);

		Destroy (tower);
		towerBlueprint = null;
	}

	void OnMouseEnter()
	{
		if (EventSystem.current.IsPointerOverGameObject ()) {
			return;
		}

		if (!buildManager.CanBuild) {
			return;
		}
			
		if (buildManager.HasGold) {
			rend.material.color = hoverColor;
		} else {
			rend.material.color = insufficientColor;
		}
	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}

}
