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
				anim.CrossFade("L_handSwat", 0.5f, PlayMode.StopAll);
            }
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("Playing Right Hand Swat Animation");
				anim.CrossFade("R_handSwat", 0.5f, PlayMode.StopAll);
            }
            if (Input.GetKeyDown("q") && Input.GetKeyDown("e"))
            {
                Debug.Log("Playing Both Hand Swat Animation");
				anim.CrossFade("B_swat", 0.5f, PlayMode.StopAll);
            }
        }

	}
}
