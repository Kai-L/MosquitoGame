using UnityEngine;
using System.Collections;

public class Suckspots : MonoBehaviour {

	public GameObject[] suckspots;
	public int currentSuckspot;
	public float Timer;

	private float tempTimer;

	void Start () 
	{
		SetNewSuckspot ();
		Timer = 20F;
		tempTimer = Timer;
	}

	void Update()
	{
		Timer = Timer - Time.deltaTime;
		if (Timer < 0F) {
			SetNewSuckspot ();
			Timer = tempTimer;
		}


	}

	public void SetNewSuckspot(){
		currentSuckspot = Random.Range (0, suckspots.Length);
		for (int i = 0; i < suckspots.Length; i++) 
		{
			if (i == currentSuckspot) {
				suckspots [i].SetActive(true);
			} else {
				suckspots [i].SetActive(false);
			}
		}
	}
}
