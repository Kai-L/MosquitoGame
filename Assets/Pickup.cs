using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public Weapon currentObject;
	public Transform rightHand;

	void Update () {
		if (currentObject != null) {
			currentObject.snapPoint.position = rightHand.position;
			currentObject.transform.parent = rightHand;
		}
	}
}
