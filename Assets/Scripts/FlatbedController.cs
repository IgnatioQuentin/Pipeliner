
using UnityEngine;
using System.Collections;

public class FlatbedController : MonoBehaviour {
	public int angle;
	public int maxAngle;
	public GameObject hatch;

	
	// Use this for initialization
	void Start () {
	} 
	void rotateClockwise() {
		this.transform.Rotate(0, 0, 1.0f);
		hatch.transform.Rotate(0, 0, 5.0f);
	}
	
	void rotateCounterClockwise() {
		this.transform.Rotate(0, 0, -1.0f);
		hatch.transform.Rotate(0, 0, -5.0f);
	}
	
	public void handleInput(float v) {
		if (v > 0f) { 
			if (angle < maxAngle) {
				angle++;
				rotateClockwise ();
			}
		}
		
		if (v < 0f) {
			if (angle > 0) {
				angle--;
				rotateCounterClockwise ();
			}
		}
	}
	
	
	void Update(){
	}
}