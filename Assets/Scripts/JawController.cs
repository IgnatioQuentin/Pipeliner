using UnityEngine;
using System.Collections;

public class JawController : MonoBehaviour {
	private Animator anim;
	private bool open;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (open) {
				anim.SetBool ("open", false);
				open = !open;
			} else {
				anim.SetBool ("open", true);
				open = !open;
			}
		}


	}
}
