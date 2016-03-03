using UnityEngine;
using System.Collections;

public class Lightswitch : MonoBehaviour {

	public GameObject light;
	public bool currentLight;


	void OnCollisionEnter(Collision c)
	{
		currentLight = !currentLight;
		light.SetActive (currentLight);
	}
}
