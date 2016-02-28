using UnityEngine;
using System.Collections;

public class MosquitoSound : MonoBehaviour {

	public AudioClip mosquitoBuzz;

	private AudioSource source;
	private float volLowRange = 0.5f;
	private float volHighRange = 1.0f;

	// Use this for initialization
	void Awake () {

		source = GetComponent<AudioSource> ();


	}
	
	// Update is called once per frame
	void Update () {
		source.PlayOneShot (mosquitoBuzz, 1F);
	}
}
