using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SleepySwat : MonoBehaviour {

	Animator anim;
    //public Animation lAnim;
    //public Animation rAnim;
	public NetworkIdentity networkIdentity;
    Pickup pickup;

    AudioSource audioSource;
    public AudioClip swingSound;

	public float cameraAngle;
	public float setSwat;

    public bool canSwat = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pickup = GetComponent<Pickup>();

		anim = GetComponent<Animator> ();

    }
    
	void Update() {
		if (!networkIdentity.isLocalPlayer) {
			return;
		}

        if (!canSwat)
        {
            return;
        }

		cameraAngle = GetComponent<RotateHead> ().xAxis;
		if (cameraAngle > 30) {
			setSwat = 0;
		} else if (cameraAngle > -10) {
			setSwat = .5f;
		} else {
			setSwat = 1;
		}

		if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Playing Left Hand Swat Animation");
			anim.Play ("L_Swat");
			anim.SetFloat ("L_swatMeter", setSwat);
            if(pickup.currentObject != null)
            {
                pickup.currentObject.PlaySwingSound();
            }
            else
            {
                audioSource.PlayOneShot(swingSound);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Playing Right Hand Swat Animation");
			anim.Play ("R_Swat");
			anim.SetFloat ("R_swatMeter", setSwat);
            if (pickup.currentObject != null)
            {
                pickup.currentObject.PlaySwingSound();
            }
            else
            {
                audioSource.PlayOneShot(swingSound);
            }
        }
	}
}
