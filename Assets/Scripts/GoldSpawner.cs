using UnityEngine;
using System.Collections;

public class GoldSpawner : MonoBehaviour {

	public GameObject gold;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log ("Input: " + Input.mousePosition);
	
		if (Input.GetMouseButton(0)) {
			Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			GameObject clone = (GameObject)Instantiate(gold, new Vector3 (target.x, target.y, 0f ), Quaternion.identity);
		}
	}
}
