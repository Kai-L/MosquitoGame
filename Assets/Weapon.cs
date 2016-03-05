using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public Transform snapPoint;
	public Pickup sleepyPickup;

    AudioSource audioSource;

    public AudioClip weaponSwing;
    public AudioClip weaponImpact;

	void Start(){
        audioSource = GetComponent<AudioSource>();
		snapPoint = gameObject.transform;
	}

	void Update(){
		if (sleepyPickup.currentObject != this) {
			transform.parent = null;
			GetComponent<Rigidbody> ().isKinematic = false;
		}
	}

	void OnMouseDown() 
	{
		sleepyPickup = FindObjectOfType<Pickup> ();

		sleepyPickup.currentObject = this;

		GetComponent<Rigidbody> ().isKinematic = true;
	}

    public void PlaySwingSound()
    {
        audioSource.PlayOneShot(weaponSwing);
    }

    public void PlayImpactSound()
    {
        audioSource.PlayOneShot(weaponImpact);
    }
}
