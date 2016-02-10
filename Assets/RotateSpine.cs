using UnityEngine;
using System.Collections;

public class RotateSpine : MonoBehaviour {

    public Transform head;
    public float rotateSpeed = 1;

	void Update () {

        Quaternion tempRot = transform.localRotation;
        tempRot = Quaternion.Lerp(tempRot, head.localRotation, rotateSpeed);
        transform.localRotation = tempRot;

	}
}
