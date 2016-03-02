using UnityEngine;
using System.Collections;

public class WeaponSounds : MonoBehaviour {

	private AudioSource audioSource;

	public AudioClip audioClip;
	public KeyCode key;

	bool hasPlayed = false;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	void Update () {
		if (Input.GetKey(key) && !hasPlayed) {
			audioSource.PlayOneShot(audioClip);
			hasPlayed = true;
		}
	}
}
