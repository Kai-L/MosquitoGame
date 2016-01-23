using UnityEngine;
using System.Collections;

public class MosquitoControl : MonoBehaviour {

    [Header("Speed Controls")]
    public float flightSpeed;
    public float forwardMoveSpeed;
    public float strafeMoveSpeed;
    public float hRotationSpeed;
    public float vRotationSpeed;
    public float deceleration;

    int currentFlap = 0;

    [Header("Axis Tests")]
    public float xAxis;
    public float yAxis;

	void OnMouseDown()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

	void Update () {

        xAxis += -Input.GetAxis("ViewHorizontal") * hRotationSpeed * Time.deltaTime;
        yAxis += Input.GetAxis("ViewVertical") * vRotationSpeed * Time.deltaTime;

        transform.eulerAngles = new Vector3(xAxis, yAxis, 0.0f);

        // Flapping Controls

        if (Input.GetMouseButtonDown(currentFlap))
        {
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * flightSpeed);
            if (currentFlap == 0)
            {
                currentFlap = 1;
            }
            else
            {
                currentFlap = 0;
            }
        }

        // Forward Movement Controls

        if (Input.GetAxis("Vertical") > 0)
        {
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * forwardMoveSpeed * Time.deltaTime);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            GetComponent<Rigidbody>().AddRelativeForce(-Vector3.forward * (forwardMoveSpeed/2) * Time.deltaTime);
        }
        else
        {
            // TO-DO: Decelerate
            //GetComponent<Rigidbody>().AddRelativeForce(-Vector3.forward);
        }
	}
}
