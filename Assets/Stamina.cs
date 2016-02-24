using UnityEngine;
using System.Collections;

public class Stamina : MonoBehaviour {

	public float stamina;
	public float RecoverMultiplier;

	private bool isMax;
	private float staminaMax;

	void Start () {
		isMax = true;
		staminaMax = stamina;

	}
	
	// Update is called once per frame
	void Update () {
		//Decrease stamina when swat button pressed
		if (Input.GetKeyDown ("q")) {
			stamina = stamina - 10F;
			Debug.Log ("Stamina Decreased");
		} else if (Input.GetKeyDown ("e")) {
			stamina = stamina - 10F;
			Debug.Log ("Stamina Decreased");
		} else if (Input.GetKeyDown ("q") && Input.GetKeyDown ("e")) {
			stamina = stamina - 10F;
			Debug.Log ("Stamina Decreased");
		}

		//Bool setup for isMax
		if (stamina < staminaMax) {
			isMax = false;
		} else {
			isMax = true;
			Debug.Log ("Stamina at Max");
		}

		//Stamina recovery
		if (isMax == false) {
			stamina = stamina + (Time.deltaTime * RecoverMultiplier);
		}

	}
}
