using UnityEngine;
using System.Collections;

public class RandomGoldSpawnerByVector : MonoBehaviour {

	public GameObject gold;
	public GameObject GoldSpawn;
	public int spawnsPerSecond;
	public float forceX;
	public float forceY;
	public int forceMag;

	private int counter;
	private int cutOff;

	private float randomOffsetX;
	private float randomOffsetY;

	public GameObject terrain;
	// Use this for initialization
	void Start () {
		cutOff = spawnsPerSecond * 60;
		Random.Range(-3, 3);
		randomOffsetX = Random.value;
		randomOffsetY = Random.value;
	}
	
	// Update is called once per frame
	void Update () {
		if(counter == 0){
			GameObject spawn = (GameObject)Instantiate(gold, GoldSpawn.transform.position , Quaternion.identity);
			spawn.rigidbody2D.AddForce(new Vector2(((forceX * forceMag) + randomOffsetX), ((forceY * forceMag) + randomOffsetY)));
		}

		counter++;

		if(counter > cutOff){
			counter = 0;
		}
	}
}
