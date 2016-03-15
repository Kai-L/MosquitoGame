using UnityEngine;
using System.Collections;

public class Lightswitch : MonoBehaviour {

	public GameObject light;
	public GameObject lightSwitch;
	public bool lightActive;

	void OnCollisionEnter(Collision c)
	{
		lightActive = !lightActive;
		light.SetActive (lightActive);
		lightSwitch.transform.Rotate(Vector3.down * Time.deltaTime, 0, 0);
	}

	void OnControllerColliderHit(ControllerColliderHit c)
	{
		lightActive = !lightActive;
		light.SetActive (lightActive);
		lightSwitch.transform.Rotate(Vector3.down * Time.deltaTime, 0, 0);
	}
}
