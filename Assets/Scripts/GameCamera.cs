using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {
	private GameLogic logic;
	private Transform target;
	private float trackSpeed = 10;
	private string guiString = "";
	
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
			Vector3 v = transform.position;
			v.x = target.position.x;
			v.y = target.position.y;
			transform.position = Vector3.MoveTowards (transform.position, v, trackSpeed * Time.deltaTime);
		}
	}
	void OnGUI () {
		guiString = "Score: " + logic.getScore();
		if(logic.getPlayback()){
			guiString += "\n Playback";
		}
		if(logic.getRecording()){
			guiString += "\n Recording";
		}
		GUI.Box(new Rect(Screen.width/2,10,100,40), guiString);
	}
}