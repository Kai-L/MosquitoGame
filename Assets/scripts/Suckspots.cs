using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Suckspots : NetworkBehaviour {

	public GameObject[] suckspots;

    [SyncVar]
	public int currentSuckspot;

    [SyncVar]
    public int seed;

    public float Timer;

	private float tempTimer;

	void Start () 
	{
        Random.seed = seed;
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
