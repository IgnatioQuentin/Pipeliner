using UnityEngine;
using System.Collections;

public class goldShredder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.name.Contains("Gold")){
			Destroy(other.gameObject);
		}
	}
}
