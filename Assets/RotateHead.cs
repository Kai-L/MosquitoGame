﻿using UnityEngine;
using System.Collections;

public class RotateHead : MonoBehaviour {

    public float hRotationSpeed;
    public float vRotationSpeed;

    public float xAxis;
    public float yAxis;

	public Camera mainCam;

    void Start () {
		mainCam = Camera.main;
	}
	
    void Update () {

        xAxis += -Input.GetAxis("ViewHorizontal") * hRotationSpeed * Time.deltaTime;
        yAxis += Input.GetAxis("ViewVertical") * vRotationSpeed * Time.deltaTime;

        transform.eulerAngles = new Vector3(0, yAxis, 270);

		mainCam.transform.eulerAngles = new Vector3 (xAxis, yAxis, 0);
    }
}
