using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public Transform snapPoint;
	public Pickup sleepyPickup;

	void Start(){
		snapPoint = gameObject.transform;
	}

	void Update(){
		if (sleepyPickup.currentObject != this) {
			transform.parent = null;
			GetComponent<Rigidbody> ().isKinematic = false;
		}
	}

	void OnMouseDown() 
	{
		sleepyPickup = FindObjectOfType<Pickup> ();

		sleepyPickup.currentObject = this;

		GetComponent<Rigidbody> ().isKinematic = true;
	}
}
