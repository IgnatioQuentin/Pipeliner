using UnityEngine;
using System.Collections;

public class TardScript : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("Trigger Collide");
		if(other.gameObject.name == "GoldDestroyer"){
			//Debug.Log("Trigger Destroy");
			Destroy(this.gameObject);
		} else if(other.gameObject.name == "pipeExit"){
			Debug.Log("SCORE!");
			Destroy(this.gameObject);
		}
	}	
}
