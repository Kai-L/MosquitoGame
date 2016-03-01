using UnityEngine;
using System.Collections;

public class RadioSound : MonoBehaviour {

	public AudioClip radio;

	private AudioSource source;
	// Use this for initialization
	void Awake () {
		source = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter (Collision col){
		if (source.isPlaying) {
			source.Pause ();
		} else {
			source.Play ();
		}
	}
		
	void Update () {
		/*if (Input.GetKeyDown (KeyCode.F)) {
			if (source.isPlaying) {
				source.Pause();
			} else {
				source.Play();
			}
		}*/
	}
}
