using UnityEngine;
using System.Collections;

public class MuteMosquitoBuzz : MonoBehaviour {

	AudioSource audio;

	void Start() {
		audio = GetComponent<AudioSource>();
	}

	void Update() {

		if (GameObject.FindGameObjectWithTag ("MosquitoCam")) {
			audio.mute = true;
		} else {
			audio.mute = false;
		}

	}
}
