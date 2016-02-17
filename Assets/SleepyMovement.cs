using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SleepyMovement : NetworkBehaviour {

	public Camera mainCamera;
	public NetworkIdentity networkIdentity;

    [Header("Speed Controls")]
    public float forwardMoveSpeed;
    public float strafeMoveSpeed;
    public float deceleration;
    public float handSpeed;

    [Header("Body Parts")]
    public Rigidbody leftHand;
    public Rigidbody rightHand;
	public Transform leftHandOrigin;
	public Transform rightHandOrigin;
	public Transform swatPoint;
	public Rigidbody torso;

	float tempForwardSpeed = 0;
	float tempStrafeSpeed = 0;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update () {

		if (!networkIdentity.isLocalPlayer) {
			Destroy (mainCamera);
			return;
		}

		/*
		Debug.Log (torso.velocity);

        if (Input.GetKey(KeyCode.Q))
        {
			leftHand.AddRelativeForce (new Vector3 (0, 0, handSpeed));
			//leftHand.rotation = Quaternion.RotateTowards(leftHand.rotation, Quaternion.Euler(0, 90, 0), handSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
			rightHand.AddRelativeForce (new Vector3 (0, 0, handSpeed));
			//rightHand.rotation = Quaternion.RotateTowards (rightHand.rotation, Quaternion.Euler (0, 90, 0), handSpeed * Time.deltaTime);
        }
		if(!Input.GetKey(KeyCode.E))
        {
			leftHand.velocity = Vector3.Lerp(leftHand.velocity, Vector3.zero, handSpeed);

			//leftHand.rotation = Quaternion.RotateTowards(leftHand.rotation, Quaternion.Euler(0, 0, 0), handSpeed * Time.deltaTime);
        }
		if (!Input.GetKey (KeyCode.Q)) 
		{
			rightHand.velocity = Vector3.Lerp(rightHand.velocity, Vector3.zero, handSpeed);

			//ightHand.rotation = Quaternion.RotateTowards (rightHand.rotation, Quaternion.Euler (0, 0, 0), handSpeed * Time.deltaTime);
		}
		*/


        // Forward Movement Controls


        if (Input.GetAxis("Vertical") > 0)
        {
			tempForwardSpeed = forwardMoveSpeed;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
			tempForwardSpeed = -forwardMoveSpeed;

        }
        else
        {
			tempForwardSpeed = Mathf.Lerp (tempForwardSpeed, 0, deceleration);
        }

        // Strafe Movement Controls

        if (Input.GetAxis("Horizontal") > 0)
        {
			tempStrafeSpeed = strafeMoveSpeed;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
			tempStrafeSpeed = -strafeMoveSpeed;
        }
        else
        {
			tempStrafeSpeed = Mathf.Lerp(tempStrafeSpeed, 0, deceleration);
        }

		torso.position += transform.forward * tempForwardSpeed * Time.deltaTime;
		torso.position += transform.up * tempStrafeSpeed * Time.deltaTime; 
        
    }
}
