using UnityEngine;
using System.Collections;

public class Lamps : MonoBehaviour {

	Vector3 originalPosition;
	bool hasTurnedOff;

	void Start(){
		originalPosition = transform.position;
	}

	void Update(){

		if (hasTurnedOff) {
			return;
		} else if (Vector3.Distance (originalPosition, transform.position) > 30) {
			transform.GetComponentInChildren<Light> ().enabled = false;
			transform.FindChild ("lamp1").GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.black);
		}

	}

}
