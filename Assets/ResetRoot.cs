using UnityEngine;
using System.Collections;

public class ResetRoot : MonoBehaviour {

	public float defaultRotX;
	public float defaultRotY;
	public float defaultRotZ;

	public float rotSpeed;

	void Update () {

		Vector3 tempRot = transform.localEulerAngles;

		if (!Input.anyKey) {
			tempRot = Vector3.Lerp(tempRot, new Vector3(defaultRotX, defaultRotY, defaultRotZ), rotSpeed);
		}

		transform.localEulerAngles = tempRot;
	}
}
