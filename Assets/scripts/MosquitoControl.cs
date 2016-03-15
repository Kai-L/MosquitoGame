using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class MosquitoControl : NetworkBehaviour {

	Animator anim;

	//int isFlying = Animator.StringToHash("isFlying");

	bool isFlapping = false;
	bool usesGravity = true;

	[Header("Player Select")]
	public int player;

    [Header("Speed Controls")]
    public float flightSpeed;
    public float forwardMoveSpeed;
    public float strafeMoveSpeed;
    public float hRotationSpeed;
    public float vRotationSpeed;
    public float deceleration;
	public float gravity;

    int currentFlap = 0;

    [Header("Axis Tests")]
    public float xAxis;
    public float yAxis;

	GameObject mainCamera;
	CharacterController character;

    LocalPlayer localPlayer;

    [SyncVar]
    public bool isAlive;

    public override float GetNetworkSendInterval ()
	{
		return 0;
	}

	void Start(){
        localPlayer = FindObjectOfType<LocalPlayer>();
		character = GetComponent<CharacterController> ();
		mainCamera = this.gameObject.transform.FindChild ("Main Camera").gameObject;

		//accessing the animator
		anim = GetComponent<Animator>();
	}

	void OnMouseDown()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
		
	public override void OnStartLocalPlayer()
	{
		//GetComponent<MeshRenderer> ().material.color = Color.red;
		FindObjectOfType<LocalPlayer>().localPlayer = this.gameObject;
	}

	void FixedUpdate () {

		if (!isLocalPlayer) 
		{
			Destroy (mainCamera);
			return;
		}

		if (!isFlapping && usesGravity) {
			character.Move (Vector3.down * Time.deltaTime * gravity);
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

            //GetComponent<Rigidbody>().AddForce(Vector3.up * flightSpeed);
			StartCoroutine(Flap());

			//animator stuff
			anim.SetBool ("isFlying", true);
			anim.SetBool ("isFalling", false);
			anim.SetBool ("isIdle", false);

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
		character.Move(transform.forward * tempVel.z * Time.deltaTime);

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

		character.Move (transform.right * tempVel.x * Time.deltaTime);

        //GetComponent<Rigidbody>().velocity = transform.TransformDirection(tempVel);
	}

	IEnumerator Flap()
	{
		isFlapping = true;
		float startingValue = 0.0f;
		float endingValue = 10.0f;
		while (startingValue < endingValue) {
			if (startingValue >= endingValue - 1) {
				isFlapping = false;
			}
			startingValue += 1f;
			Mathf.Lerp (flightSpeed, flightSpeed * 2, startingValue / endingValue);
			character.Move(transform.up * flightSpeed * Time.deltaTime);
			yield return null;
		}
	}

    void OnControllerColliderHit(ControllerColliderHit c)
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

		usesGravity = true;
		//GetComponent<Rigidbody> ().useGravity = true;
		//GetComponent<Rigidbody> ().drag = 0;
    }

    void SetSlowMovement()
    {
        if (GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
            strafeMoveSpeed = 0;
            forwardMoveSpeed = 0;
        }
        else
        {
            strafeMoveSpeed = 1;
            forwardMoveSpeed = 1;
        }

		usesGravity = true;
		//GetComponent<Rigidbody> ().useGravity = false;
		//GetComponent<Rigidbody> ().drag = 1;

		anim.SetBool ("isIdle", true);
		anim.SetBool ("isFalling", false);
		anim.SetBool ("isFlying", false);
    }
}
