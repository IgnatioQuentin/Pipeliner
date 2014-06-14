using UnityEngine;
using System.Collections;

public class GrabInTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerStay2D(Collider2D other) {
			if (Input.GetKeyDown (KeyCode.LeftShift) && (other.tag == "Gold" || other.tag == "Player")) {
			Debug.Log ("Nigga i grabbed dat shit!");

			}
		}
	// Update is called once per frame
	void Update () {
	
	}
}
