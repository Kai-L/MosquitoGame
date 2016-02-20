using UnityEngine;
using System.Collections;

public class RotateSpine : MonoBehaviour {

    public Transform head;
    public float rotateSpeed = 1;

	void Update () 
	{

        Quaternion tempRot = transform.rotation;
		tempRot.y = Mathf.Lerp(tempRot.y, head.rotation.x, rotateSpeed);
        transform.rotation = tempRot;

	}
}
