using UnityEngine;
using System.Collections;

public class AmbientSound : MonoBehaviour {

	public AudioClip ambientSound;
	public AudioClip citySound;

	private AudioSource source;
	private int randVolume;
	private float randTime = 60;
	private float timeCounter;

	// Use this for initialization
	void Awake () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		source.PlayOneShot(ambientSound);

		if (timeCounter > randTime) {
			randTime = Random.Range(0, 120);
			timeCounter = 0;
			VariableVolume();
			source.PlayOneShot (citySound, randVolume);
		}

		timeCounter += Time.deltaTime;
	}

	void VariableVolume() {
		randVolume = Random.RandomRange(0, 2);

		switch (randVolume) {
			case 0:
				source.volume = 1f;
				break;
			case 1:
				source.volume = 0f;
				break;
			case 2:
				source.volume = .5f;
				break;
		}
	}
}
