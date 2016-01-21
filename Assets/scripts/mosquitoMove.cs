using UnityEngine;
using System.Collections;

public class mosquitoMove : MonoBehaviour {

	public float time;
	private float tempt;
	// Use this for initialization
	void Start () {
		tempt = time;
	}
	
	// Update is called once per frame
	void Update () {
		if (time > 0) {
			transform.Translate (Vector3.forward * Time.deltaTime);
			time = time - 0.5f;
		} else if ((-100 <= time) && (time <= 0)) {
			transform.Translate (Vector3.back * Time.deltaTime);
			time = time - 0.5f;
		} else {
			time = tempt;
		}
	}
}
