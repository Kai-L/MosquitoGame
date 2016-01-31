using UnityEngine;
using System.Collections;

public class SleepySwat : MonoBehaviour {

	//public Animation anim;
	void Start() {
		
	}
	void Update() {
		if (Input.GetKeyDown ("Q")) {
			GetComponent<Animation>().Play ("leftSwat");
		}
	}
}
