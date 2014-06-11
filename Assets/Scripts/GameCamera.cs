using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {
	private GameLogic logic;
	private Transform target;
	private float trackSpeed = 10;
	
	void Start() {
		logic = this.GetComponentInParent<GameLogic>();
	}
	// Set target
	public void SetTarget(Transform t) {
		target = t;
	}
	
	// Track target
	void LateUpdate() {
		if (target) {
			var v = transform.position;
			v.x = target.position.x;
			transform.position = Vector3.MoveTowards (transform.position, v, trackSpeed * Time.deltaTime);
		}
	}
	void OnGUI () {
		GUI.Box(new Rect(Screen.width/2,10,100,40), "Score: " + logic.getScore());

	}
}