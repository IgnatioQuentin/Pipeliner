using UnityEngine;
using System.Collections;

public class MoveOnTrigger : MonoBehaviour {
	public float moveForce;
	public bool right;
	public bool left;
	private float newX;
	// Use this for initialization
	void Start () {
		if (right && left)
			left = !left;
	}

	void OnTriggerStay2D (Collider2D other) {
		if (right && other.tag != "Kinematic") {
			other.transform.Translate (moveForce * Time.deltaTime, 0, 0, Camera.main.transform);
		}

		if (left && other.tag != "Kinematic") {
			other.transform.Translate (-moveForce * Time.deltaTime, 0, 0, Camera.main.transform);
		}
	}
}
