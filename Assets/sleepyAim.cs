using UnityEngine;
using System.Collections;

public class sleepyAim : MonoBehaviour {

    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

	void Update () {

        Quaternion tempQuat = transform.localRotation;
        tempQuat.x = mainCamera.transform.rotation.x;
        transform.localRotation = tempQuat;

	}
}
