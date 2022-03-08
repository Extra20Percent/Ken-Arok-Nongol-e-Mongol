using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	private Transform target;
	private Enemy targetEnemy;

	[Header("General")]

	public float range = 15f;

	[Header("Fire Settings")]
	public GameObject bulletPrefab;
	public float fireRate = 1f;
	private float fireCountdown = 0f;

	[Header("Use Laser")]
	public bool useLaser = false;
	public int damageOverTime = 30;
	public float slowPercentage = .5f;

	public LineRenderer lineRenderer;
	public ParticleSystem impactEffect;
	public Light impactLight;

	[Header("Unity Setup Fields")]
	public string enemyTag = "Enemy";

	public Transform firePoint;


	void Start () {
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
		if (useLaser) {
			impactLight.enabled = false;
			impactEffect.Stop ();
		}
	}

	void UpdateTarget ()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies) {
			float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance) {
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range) {
			target = nearestEnemy.transform;
			targetEnemy = nearestEnemy.GetComponent<Enemy> ();
		} else {
			target = null;
		}
	}
		

	void Update () 
	{
		if (target == null) {
			if (useLaser) {
				if (lineRenderer.enabled) {
					lineRenderer.enabled = false;
					impactEffect.Stop();
					impactLight.enabled = false;
				}
			}
			return;
		}

		if (useLaser) {
			Laser ();
		} else {
			if (fireCountdown <= 0f) {
				Shoot ();
				fireCountdown = 1f / fireRate;
			}
		}

		fireCountdown -= Time.deltaTime;
	}

	void Laser()
	{
		targetEnemy.TakeDamage (damageOverTime * Time.deltaTime);
		targetEnemy.Slow (slowPercentage);

		if (!lineRenderer.enabled) {
			lineRenderer.enabled = true;
			impactEffect.Play ();
			impactLight.enabled = true;
		}
		lineRenderer.SetPosition (0, firePoint.position);
		lineRenderer.SetPosition (1, target.position);

		Vector3 dir = firePoint.position - target.position;

		impactEffect.transform.position = target.position + dir.normalized;
		impactEffect.transform.rotation = Quaternion.LookRotation (dir);


	}

	void Shoot ()
	{
		GameObject bulletGO =  (GameObject)Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet> ();

		if (bullet != null) {
			bullet.Seek (target);
		}
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere (transform.position, range);
	}
}

/*	Dipake kalo ada bagian partToRotate, mending dibuat di script TowerRotate. Model candi gausah dulu.
 * Masukin di Header Unity Setup Fields biar rapi.

 	public Transform partToRotate;
	public float turnSpeed = 10f;

	//Dipake semisal mau ada partToRotate, buat gerakin bagian head tanpa basenya. Ditaruh di Update().
	//Pisahin dulu bagian partToRotatenya.
	
	void LockOnTarget()
	{
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp (partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);
	}
*/