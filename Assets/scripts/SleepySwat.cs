using UnityEngine;
using System.Collections;

public class SleepySwat : MonoBehaviour {

	public Animation anim;
	//public Animation anim;
	void Start() {
		
	}
	void Update() {
		if (Input.GetKey("q")) {
			GetComponent<Animation>().Play ("leftSwat");
		}
		if (Input.GetKey ("e")) {
			GetComponent<Animation> ().Play ("rightSwat");
		}
		if (Input.GetKey ("q") && Input.GetKey ("e")) {
			GetComponent<Animation> ().Play ("RLSwat");
		}

	}
}
