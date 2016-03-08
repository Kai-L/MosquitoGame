using UnityEngine;
using System.Collections;

public class AmbientSound : MonoBehaviour {

	public AudioClip ambientSound;
	public AudioClip[] citySounds;

	private AudioSource source;
	private int randClip;
	private float randTime;
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
			source.Stop();
			ChooseClip();
			source.PlayOneShot(citySounds[randClip]);
		}

		timeCounter += Time.deltaTime;
	}

	void ChooseClip() {
		randClip = Random.RandomRange(0, 2);

		switch (randClip) {
			case 0:
				source.clip = citySounds[0];
				break;
			case 1:
				source.clip = citySounds[1];
				break;
			case 2:
				source.clip = citySounds[2];
				break;
		}
	}
}
