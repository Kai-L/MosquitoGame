using UnityEngine;
using System.Collections;

public class SleepyMovement : MonoBehaviour {

    [Header("Speed Controls")]
    public float forwardMoveSpeed;
    public float strafeMoveSpeed;
    public float deceleration;
    public float handSpeed;

    [Header("Body Parts")]
    public Rigidbody leftHand;
    public Rigidbody rightHand;
    public Rigidbody leftKnee;
    public Rigidbody rightKnee;

    public Vector3 targetLPos;
    public Vector3 targetRPos;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update () {

        if (!Input.anyKey)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                targetLPos = hit.point;
                leftHand.AddForce((targetLPos - leftHand.position) * handSpeed * Time.smoothDeltaTime);
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                targetRPos = hit.point;
                rightHand.AddForce((targetRPos - rightHand.position) * handSpeed * Time.smoothDeltaTime);
            }
        }
        if(!Input.GetKey(KeyCode.E) && !Input.GetKey(KeyCode.Q))
        {
            leftHand.AddForce((Vector3.zero - leftHand.position) * handSpeed * Time.smoothDeltaTime);
            rightHand.AddForce((Vector3.zero - rightHand.position) * handSpeed * Time.smoothDeltaTime);
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
            //tempVel.x = Mathf.Lerp(tempVel.x, 0, deceleration);
            //tempVel.z = Mathf.Lerp(tempVel.z, 0, deceleration);
            //GetComponent<Rigidbody>().AddRelativeForce(-Vector3.forward);
        }

        // Strafe Movement Controls
		/*
        if (Input.GetAxis("Horizontal") > 0)
        {
            tempVel.x = strafeMoveSpeed;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            tempVel.x = -strafeMoveSpeed;
        }
        else
        {
            tempVel.z = Mathf.Lerp(tempVel.z, 0, deceleration);
            tempVel.x = Mathf.Lerp(tempVel.x, 0, deceleration);
        }
        */

        if(leftKnee.velocity.magnitude < rightKnee.velocity.magnitude)
        {
			leftKnee.velocity = transform.InverseTransformVector (tempVel);
        }
        else
        {
            rightKnee.velocity = transform.InverseTransformVector(tempVel);
        }
        //GetComponent<Rigidbody>().velocity = transform.TransformDirection(tempVel);
    }
}
