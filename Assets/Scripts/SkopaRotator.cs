using UnityEngine;
using System.Collections;

public class SkopaRotator : MonoBehaviour {
	public int angle;
	
	// Use this for initialization
	void Start () {
	} 
	void rotateClockwise() {
		transform.Rotate(0, 0, 1.0f);
	}
	
	void rotateCounterClockwise() {
		transform.Rotate (0, 0, -1.0f);
	}
	
	void handleAngle() {
		if (Input.GetKey (KeyCode.W)) { 
				if (angle < 180) {
					angle++;
					rotateClockwise ();
				} else {
					angle--;
					rotateCounterClockwise();
				}
		}
			
			if (Input.GetKey (KeyCode.S)) {
				if (angle > 0) {
					angle--;
					rotateCounterClockwise ();
				} else {
					angle++;
					rotateClockwise ();

				}
			}
		}

	
	void Update(){ 
		handleAngle ();
	}
}