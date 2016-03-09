using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class RotateHead : NetworkBehaviour {

    public float hRotationSpeed;
    public float vRotationSpeed;

    public float xAxis;
    public float yAxis;

	public Camera mainCam;

    //public Transform Center;
    //public Transform rightClavicle;

    //public Transform leftShoulder;
    //public Transform rightShoulder;

    void Start () {
		//mainCam = Camera.main;
	}

    void Update () {

		if (!isLocalPlayer) {
			return;
		}

        xAxis += -Input.GetAxis("ViewHorizontal") * hRotationSpeed * Time.deltaTime;
        yAxis += Input.GetAxis("ViewVertical") * vRotationSpeed * Time.deltaTime;

		transform.eulerAngles = new Vector3(0, yAxis, 0);

		xAxis = Mathf.Clamp (xAxis, -50, 70);

		mainCam.transform.eulerAngles = new Vector3 (xAxis, yAxis, 0);

		//Center.eulerAngles = new Vector3(xAxis, mainCam.transform.eulerAngles.y + 180, 0);

		//rightShoulder.localEulerAngles = new Vector3 (xAxis, 0, 0);
        //leftShoulder.localEulerAngles = new Vector3(xAxis, 0, 0);

    }
}
