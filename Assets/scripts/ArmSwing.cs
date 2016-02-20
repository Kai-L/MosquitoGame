using UnityEngine;
using System.Collections;

public class ArmSwing : MonoBehaviour {

	public KeyCode key;
	public float swingSpeed;

	public float xRot;
	public float yRot;
	public float zRot;

	void Update () {
	
		if (Input.GetKey (key)) {
			
			Quaternion tempRot = transform.localRotation;

			tempRot.x += xRot;
			tempRot.y += yRot;
			tempRot.z += zRot;

			transform.localRotation = tempRot;

			GetComponent<Rigidbody> ().useGravity = false;

		}

	}
}
