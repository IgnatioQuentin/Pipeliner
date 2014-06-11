using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	private GameLogic logic;
	// Use this for initialization
	void Start () {
		logic = GetComponentInParent<GameLogic>();
	}
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.name.StartsWith("Gold")){
			logic.scoreOne();
			Destroy(other.gameObject);
		}
	}
	
}