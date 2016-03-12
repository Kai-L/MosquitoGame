using UnityEngine;
using System.Collections;

public class AmbientSound : MonoBehaviour {

	public AudioSource ambientSource;
	public AudioClip ambientSound;

	public AudioSource citySource;
	public AudioClip[] citySounds;

	private int randClip;
	private float randTime;
	private float timeCounter;

	// Use this for initialization
	void Awake () {
		ambientSource.PlayOneShot(ambientSound);
	}
	
	// Update is called once per frame
	void Update () {
		if (timeCounter > randTime) {
			randTime = Random.Range(0, 120);
			timeCounter = 0;
			citySource.Stop();
			ChooseClip();
			citySource.PlayOneShot(citySounds[randClip]);
		}

		timeCounter += Time.deltaTime;
	}

	void ChooseClip() {
		randClip = Random.RandomRange(0, 2);

		switch (randClip) {
			case 0:
			citySource.clip = citySounds[0];
				break;
			case 1:
			citySource.clip = citySounds[1];
				break;
			case 2:
			citySource.clip = citySounds[2];
				break;
		}
	}
}
