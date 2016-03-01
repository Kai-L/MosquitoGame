using UnityEngine;
using System.Collections;

public class AmbientSound : MonoBehaviour {

	public AudioClip ambientSound;

	private AudioSource source;

	// Use this for initialization
	void Awake () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		source.Play ();
	}
}
