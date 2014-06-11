using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {
	private int score;
	// Use this for initialization
	void Start () {
		score = 0;
	}
	public void scoreOne(){
		score++;
	}
	public int getScore(){
		return this.score;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
