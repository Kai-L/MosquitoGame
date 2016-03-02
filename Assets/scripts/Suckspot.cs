using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Suckspot : MonoBehaviour {

	void OnTriggerEnter (Collider c) {
		if (c.gameObject.tag == "mosquito") {
			PlayerPrefs.SetInt ("mosquitoWin", PlayerPrefs.GetInt ("mosquitoWin", 0) + 1);
			Debug.Log ("Mosquito wins!");
			SceneManager.LoadScene ("Menu_NetworkSelect");
		}
	}
}
