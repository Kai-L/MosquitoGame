using UnityEngine;
using System.Collections;

public class RotateSpine : MonoBehaviour {

    public Transform head;
    public float rotateSpeed = 1;

	void Update () 
	{

        Quaternion tempRot = transform.rotation;
        tempRot.x = Mathf.Lerp(tempRot.x, head.localRotation.x, rotateSpeed);
        transform.rotation = tempRot;

	}
}
