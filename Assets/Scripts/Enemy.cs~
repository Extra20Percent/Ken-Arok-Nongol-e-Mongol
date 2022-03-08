using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	[HideInInspector]
	public float speed;
	public float startSpeed = 10f;
	public float starthealth = 100f;
	private float health;
	public int goldGain = 25;
	public int damageToPlayer = 1;

	private bool isDead = false;

	[Header("Unity Setup Things")]
	public Image healthBar;
	public GameObject deathEffect;

	void Start()
	{
		speed = startSpeed;
		health = starthealth;
	}

	public void TakeDamage(float amount)
	{
		health -= amount;

		healthBar.fillAmount = health/starthealth;

		if (health <= 0 && !isDead) {
			Die ();
		}
	}

	public void Slow(float percentage)
	{
		speed = startSpeed * (1f - percentage);
	}

	void Die()
	{
		isDead = true;

		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);

		PlayerStats.Gold += goldGain;

		WaveSpawner.EnemiesAlive--;

		Destroy (gameObject);


	}
}
