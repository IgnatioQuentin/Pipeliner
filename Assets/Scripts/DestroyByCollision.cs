using UnityEngine;
using System.Collections;

public class DestroyByCollision: MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.name.StartsWith("Gold")){
			Debug.Log("Triggered Collision");
			Destroy(other.gameObject);
		}
	}
	
}
