
using UnityEngine;
using System.Collections;

public class FlatbedController : MonoBehaviour {
	public int angle;
	public int maxAngle;
	
	// Use this for initialization
	void Start () {
	} 
	void rotateClockwise() {
		this.transform.Rotate(0, 0, 1.0f);
	}
	
	void rotateCounterClockwise() {
		this.transform.Rotate (0, 0, -1.0f);
	}
	
	void handleAngle() {
		if (Input.GetKey (KeyCode.W)) { 
			if (angle < maxAngle) {
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