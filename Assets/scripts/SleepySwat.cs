using UnityEngine;
using System.Collections;

public class SleepySwat : MonoBehaviour {

	public Animation anim;
    
	void Update() {
        if (GetComponent<Animation>().isPlaying == false)
        {
            if (Input.GetKeyDown("q"))
            {
                Debug.Log("Playing Left Hand Swat Animation");
                GetComponent<Animation>().Play("L_handSwat");
            }
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("Playing Right Hand Swat Animation");
                GetComponent<Animation>().Play("R_handSwat");
            }
            if (Input.GetKeyDown("q") && Input.GetKeyDown("e"))
            {
                Debug.Log("Playing Both Hand Swat Animation");
                GetComponent<Animation>().Play("B_handSwat");
            }
        }

	}
}
