using UnityEngine;
using System.Collections;

public class Suckspot : MonoBehaviour {

	void OnTriggerEnter (Collider c) {
		if (c.gameObject.tag == "mosquito") {
			Destroy (GameObject.FindGameObjectWithTag ("Player"));
		}
	}
}
