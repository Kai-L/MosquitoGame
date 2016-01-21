using UnityEngine;
using System.Collections;

public class lightsOnOff : MonoBehaviour {

	public Light myLight;
	public GameObject Switch;

	// Use this for initialization
	void Start () {
		myLight = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.F)) {
			myLight.enabled = !myLight.enabled;
		}

	}
}
