using UnityEngine;
using System.Collections;

public class Lightswitch : MonoBehaviour {

	public GameObject light;
	public bool lightActive;


	void OnCollisionEnter(Collision c)
	{
		lightActive = !lightActive;
		light.SetActive (lightActive);
	}
}
