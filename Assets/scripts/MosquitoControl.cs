using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class MosquitoControl : NetworkBehaviour {

	[Header("Player Select")]
	public int player;

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

	GameObject mainCamera;

    public override float GetNetworkSendInterval ()
	{
		return 0;
	}

	void Start(){
		mainCamera = this.gameObject.transform.FindChild ("Main Camera").gameObject;
	}

	void OnMouseDown()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer> ().material.color = Color.red;
	}

	void Update () {

		if (!isLocalPlayer) 
		{
			Destroy (mainCamera);
			return;
		}

		if (Input.GetKey (KeyCode.LeftShift)) {
			Cursor.lockState = CursorLockMode.None;
		}

        xAxis += -Input.GetAxis("ViewHorizontal") * hRotationSpeed * Time.deltaTime;
        yAxis += Input.GetAxis("ViewVertical") * vRotationSpeed * Time.deltaTime;

        transform.eulerAngles = new Vector3(xAxis, yAxis, 0.0f);

        // Flapping Controls

        if (Input.GetMouseButtonDown(currentFlap))
        {
            SetFastMovement();

            GetComponent<Rigidbody>().AddForce(Vector3.up * flightSpeed);

            if (currentFlap == 0)
            {
                currentFlap = 1;
            }
            else
            {
                currentFlap = 0;
            }
        }

        Vector3 tempSpeed = GetComponent<Rigidbody>().velocity;
        tempSpeed.y = Mathf.Clamp(tempSpeed.y, -flightSpeed, flightSpeed/2);
        GetComponent<Rigidbody>().velocity = tempSpeed;

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
            tempVel.x = Mathf.Lerp(tempVel.x, 0, deceleration);
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
            tempVel.z = Mathf.Lerp(tempVel.z, 0, deceleration);
            tempVel.x = Mathf.Lerp(tempVel.x, 0, deceleration);
        }

        GetComponent<Rigidbody>().velocity = transform.TransformDirection(tempVel);
	}

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject != this.gameObject && c.gameObject.tag != "Ceiling")
        {
            SetSlowMovement();
            Vector3 tempVec = GetComponent<Rigidbody>().velocity;
            tempVec = Vector3.Lerp(tempVec, Vector3.zero, deceleration);
            GetComponent<Rigidbody>().velocity = tempVec;
        }
    }

    void SetFastMovement()
    {
        strafeMoveSpeed = 15;
        forwardMoveSpeed = 15;
    }

    void SetSlowMovement()
    {
        strafeMoveSpeed = 1;
        forwardMoveSpeed = 1; 
    }
}
