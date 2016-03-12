using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public Transform snapPoint;
	public Pickup sleepyPickup;

    AudioSource audioSource;

    public AudioClip weaponSwing;
    public AudioClip weaponImpact;

	public MeshRenderer[] outlines;

	public Shader silhouetteShader;

	private Shader startShader;

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

	void OnMouseEnter(){
		if (this.GetComponent<Weapon> () != sleepyPickup.currentObject) {
			foreach (MeshRenderer m in outlines) {
				startShader = m.material.shader;
				m.material.shader = silhouetteShader;
			}
		}
	}

	void OnMouseExit(){
		foreach (MeshRenderer m in outlines) {
			m.material.shader = startShader;
		}
	}
}
