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

        Vector3 tempVel = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);

        if (Input.GetAxis("Vertical") > 0)
        {
            //GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * forwardMoveSpeed * Time.deltaTime);
            tempVel.z = forwardMoveSpeed;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            //GetComponent<Rigidbody>().AddRelativeForce(-Vector3.forward * (forwardMoveSpeed/2) * Time.deltaTime);
            tempVel.z = -forwardMoveSpeed;
        }
        else
        {
            // TO-DO: Decelerate
            tempVel.z = Mathf.Lerp(tempVel.z, 0, deceleration);
            //GetComponent<Rigidbody>().AddRelativeForce(-Vector3.forward);
        }

        // Strafe Movement Controls

        if (Input.GetAxis("Horizontal") > 0)
        {
            tempVel.x = strafeMoveSpeed;
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            tempVel.x = -strafeMoveSpeed;
        }
        else
        {
            tempVel.x = Mathf.Lerp(tempVel.x, 0, deceleration);
        }

        GetComponent<Rigidbody>().velocity = transform.TransformDirection(tempVel);
	}
}
