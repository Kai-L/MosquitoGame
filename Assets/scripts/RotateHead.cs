using UnityEngine;
using System.Collections;

public class RotateHead : MonoBehaviour {

    public float hRotationSpeed;
    public float vRotationSpeed;

    public float xAxis;
    public float yAxis;

	public Camera mainCam;

	//public Transform Center;
	//public Transform rightClavicle;

    void Start () {
		mainCam = Camera.main;
	}

    void Update () {

        xAxis += -Input.GetAxis("ViewHorizontal") * hRotationSpeed * Time.deltaTime;
        yAxis += Input.GetAxis("ViewVertical") * vRotationSpeed * Time.deltaTime;

		transform.eulerAngles = new Vector3(0, yAxis + 180, 0);

		xAxis = Mathf.Clamp (xAxis, -50, 70);

		mainCam.transform.eulerAngles = new Vector3 (xAxis, yAxis, 0);

		//Center.eulerAngles = new Vector3(xAxis, mainCam.transform.eulerAngles.y + 180, 0);

		//rightClavicle.eulerAngles = new Vector3 (xAxis, 0, 0);

    }
}
