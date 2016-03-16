using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SleepyMovement : NetworkBehaviour {

	Animator anim;

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
	public Transform torso;

	CharacterController character;

	float tempForwardSpeed = 0;
	float tempStrafeSpeed = 0;

    LocalPlayer localPlayer;

    [SyncVar]
    public bool isAlive = true;

    public Transform spawnPoint;

    void Start()
    {
        localPlayer = FindObjectOfType<LocalPlayer>();

        spawnPoint = GameObject.Find("SleepySpawn").transform;
        transform.position = spawnPoint.position;

        networkIdentity = FindObjectOfType<NetworkIdentity>();
        Cursor.lockState = CursorLockMode.Locked;
		character = GetComponent<CharacterController> ();

		anim = GetComponent<Animator> ();
    }

	public override void OnStartLocalPlayer()
	{
		FindObjectOfType<LocalPlayer>().localPlayer = this.gameObject;
	}

    void Update () {


		if (!networkIdentity.isLocalPlayer) {
			Destroy (mainCamera.gameObject);
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
        Debug.Log("Vertical axis: " + Input.GetAxis("Vertical"));
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
            tempForwardSpeed = 0;
			anim.SetFloat ("Speed", tempForwardSpeed);
			//tempForwardSpeed = Mathf.Lerp (tempForwardSpeed, 0, deceleration);
        }

		anim.SetFloat ("Speed", Mathf.Abs(Input.GetAxis("Vertical")));
        // Strafe Movement Controls
        //Debug.Log("Horizonal axis: " + Input.GetAxis("Horizontal"));
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
            tempStrafeSpeed = 0;
			//tempStrafeSpeed = Mathf.Lerp(tempStrafeSpeed, 0, deceleration);
        }

        if(tempStrafeSpeed == 0 && tempForwardSpeed == 0)
        {
            //GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

		character.Move (transform.forward * tempForwardSpeed * Time.deltaTime);
		character.Move (transform.right * tempStrafeSpeed * Time.deltaTime);

		character.Move (new Vector3 (0, -1, 0));
		//torso.position += transform.forward * tempForwardSpeed * Time.deltaTime;
		//torso.position += transform.right * tempStrafeSpeed * Time.deltaTime;

        //Debug.Log("Velocity: " + GetComponent<Rigidbody>().velocity);
        
    }
}
