using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Suckspot : MonoBehaviour {

    SleepyMovement sleepyMovement;
    LocalPlayer localPlayer;

    void OnEnable()
    {
        sleepyMovement = FindObjectOfType<SleepyMovement>();
        localPlayer = FindObjectOfType<LocalPlayer>();
    }

	void OnTriggerEnter (Collider c) {
		if (c.gameObject.tag == "mosquito") {
            sleepyMovement.isAlive = false;
            localPlayer.localWin(c.gameObject);
            localPlayer.localLoss(sleepyMovement.gameObject);
			PlayerPrefs.SetInt ("mosquitoWin", PlayerPrefs.GetInt ("mosquitoWin", 0) + 1);
			Debug.Log ("Mosquito wins!");
			//SceneManager.LoadScene ("Menu_NetworkSelect");
		}
	}
}
