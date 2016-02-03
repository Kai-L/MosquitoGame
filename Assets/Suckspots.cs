using UnityEngine;
using System.Collections;

public class Suckspots : MonoBehaviour {

	public GameObject[] suckspots;
	public int currentSuckspot;

	void Start () 
	{
		SetNewSuckspot ();
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
