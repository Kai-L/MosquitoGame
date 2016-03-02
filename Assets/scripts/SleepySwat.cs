using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SleepySwat : MonoBehaviour {

	public Animation anim;
    //public Animation lAnim;
    //public Animation rAnim;
	public NetworkIdentity networkIdentity;
    
	void LateUpdate() {
		if (!networkIdentity.isLocalPlayer) {
			return;
		}

        if (anim.isPlaying == false)
        {
            if (Input.GetKeyDown("q"))
            {
                Debug.Log("Playing Left Hand Swat Animation");
				anim.CrossFade("L_Swat", 0.5f, PlayMode.StopAll);
            }
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("Playing Right Hand Swat Animation");
				anim.CrossFade("R_Swat", 0.5f, PlayMode.StopAll);
            }
            if (Input.GetKeyDown("q") && Input.GetKeyDown("e"))
            {
                Debug.Log("Playing Both Hand Swat Animation");
				anim.CrossFade("B_Swat", 0.5f, PlayMode.StopAll);
            }
        }

	}
}
