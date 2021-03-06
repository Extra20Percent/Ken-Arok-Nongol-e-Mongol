using UnityEngine;

public class CameraController : MonoBehaviour {

	public float panSpeed = 30f;
	public float panBorderThickness = 10f;
	public float scrollSpeed = 3f;
	public float minY = 20f;
	public float maxY = 110f;
	public float minX = 0f;
	public float maxX = 100f;
	public float minZ = 0f;
	public float maxZ = 100f;

	void Update () {
		if (GameManager.gameEnd) {
			this.enabled = false;
			return;
		}

		if (Input.GetKey ("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) {
			transform.Translate (Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		}

		if (Input.GetKey ("s") || Input.mousePosition.y <= panBorderThickness) {
			transform.Translate (Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}

		if (Input.GetKey ("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) {
			transform.Translate (Vector3.right * panSpeed * Time.deltaTime, Space.World);
		}

		if (Input.GetKey ("a") || Input.mousePosition.x <= panBorderThickness) {
			transform.Translate (Vector3.left * panSpeed * Time.deltaTime, Space.World);
		}

		float scroll = Input.GetAxis("Mouse ScrollWheel");

		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp (pos.x, minX, maxX);
		pos.y = Mathf.Clamp (pos.y, minY, maxY);
		pos.z = Mathf.Clamp (pos.z, minZ, maxZ);

		pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
		transform.position = pos;


	}
}
