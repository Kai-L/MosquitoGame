using UnityEngine;
using System.Collections;

public class KillMosquito : MonoBehaviour {

	void OnCollisionEnter (Collision col){
		if (col.gameObject.tag == "hand") {
			Destroy (gameObject);
			Debug.Log ("hit?");
		}
	}
}
