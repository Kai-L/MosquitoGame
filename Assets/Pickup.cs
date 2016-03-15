using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Pickup : NetworkBehaviour {

	public Weapon currentObject;
	public Transform rightHand;

	void Start(){
		foreach (Weapon w in FindObjectsOfType<Weapon>()) {
			w.sleepyPickup = this;
		}
	}

	void Update () {
		if (currentObject != null) {
			currentObject.snapPoint.position = rightHand.position;
			currentObject.transform.parent = rightHand;
		}
	}
}
