using UnityEngine;
using System.Collections;

public class mosquito : MonoBehaviour {

	public float visTime;
	public AudioClip mosquitoSound;

	private bool inRange;
	private float tempTime;
	private bool dead;
	private static bool isDead;
	private AudioSource source;


	void Awake (){
		source = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter( Collider other)
	{
		Debug.Log ("Player in view");
		if (inRange == false) {
			inRange = true;
			GetComponent<Renderer>().enabled = true;
		}
	}

	void OnTriggerStay (Collider other)
	{
		Debug.Log ("Player in range");
		visTime = visTime - 0.1f;
		if (visTime < 0) {
			GetComponent<Renderer> ().enabled = false;
		}
		source.PlayOneShot (mosquitoSound, 0.8f);
	}

	void OnTriggerExit (Collider other)
	{	
		Debug.Log ("Player not in view");
		visTime = tempTime;
		GetComponent<Renderer> ().enabled = false;
		inRange = false;
		source.Stop();
 	}


	// Use this for initialization
	void Start () {
		inRange = false;
		GetComponent<Renderer>().enabled = false;
		tempTime = visTime;
		dead = false;
		isDead = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (player.isHit == true) {
			isDead = player.isHit;
			dead = true;
			Debug.Log ("Mosquito Dead");
			Destroy (gameObject);
		}
	}
	
}
