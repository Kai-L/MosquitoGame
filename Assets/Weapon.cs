using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Weapon : NetworkBehaviour {

	public Transform snapPoint;
	public Pickup sleepyPickup;

    AudioSource audioSource;

    public AudioClip weaponSwing;
    public AudioClip weaponImpact;

	public MeshRenderer[] outlines;

	public Shader silhouetteShader;

	private Shader startShader;

	LocalPlayer localPlayer;

	[SyncVar]
	public bool isPickedUp = false;

	void Start(){
        audioSource = GetComponent<AudioSource>();
		snapPoint = gameObject.transform;
		localPlayer = FindObjectOfType<LocalPlayer> ();
	}

	void Update(){
		if (isPickedUp) {
			sleepyPickup.currentObject = this;
			GetComponent<Rigidbody> ().isKinematic = true;
			tag = "hand";
		}

		if (localPlayer.localPlayer.GetComponent<SleepyMovement> () == null) {
			return;
		}
		if (sleepyPickup.currentObject != this) {
			transform.parent = null;
			isPickedUp = false;
			GetComponent<Rigidbody> ().isKinematic = false;
			tag = "Weapon";
		}
	}

	void OnMouseDown() 
	{
		if (localPlayer.localPlayer.GetComponent<SleepyMovement>() == null) 
		{
			return;
		}
		sleepyPickup.currentObject = this;
		isPickedUp = true;

		GetComponent<Rigidbody> ().isKinematic = true;

		tag = "hand";
	}

    public void PlaySwingSound()
    {
        audioSource.PlayOneShot(weaponSwing);
    }

    public void PlayImpactSound()
    {
        audioSource.PlayOneShot(weaponImpact);
    }

	void OnMouseEnter(){
		if (localPlayer.localPlayer.GetComponent<SleepyMovement>() == null) 
		{
			return;
		}
		if (sleepyPickup != null) {
			if (this.GetComponent<Weapon> () != sleepyPickup.currentObject) {
				foreach (MeshRenderer m in outlines) {
					startShader = m.material.shader;
					m.material.shader = silhouetteShader;
				}
			}
		}
	}

	void OnMouseExit(){
		if (localPlayer.localPlayer.GetComponent<SleepyMovement>() == null) 
		{
			return;
		}
		if (sleepyPickup != null) {
			foreach (MeshRenderer m in outlines) {
				m.material.shader = startShader;
			}
		}
	}
}
