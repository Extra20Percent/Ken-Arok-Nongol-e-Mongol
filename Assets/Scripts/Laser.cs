using UnityEngine;

public class Laser : MonoBehaviour {

	public Transform target;

	public float speed = 100f;

	public GameObject impactEffect;

	public void Seek(Transform _target)
	{
		target = _target;
	}

	void Update () {
		if (target == null) {
			Destroy (gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame) {
			HitTarget ();
			return;
		}

		transform.Translate (dir.normalized * distanceThisFrame, Space.World);
	}

	void HitTarget()
	{
		GameObject effectIns = (GameObject)Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (effectIns, 2f);
		Destroy (target.gameObject);
		Destroy (gameObject);

	}
}
