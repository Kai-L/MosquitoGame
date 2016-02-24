using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SleepySwat : MonoBehaviour {

	public Animation anim;
	public NetworkIdentity networkIdentity;
    
	void Update() {
		if (!networkIdentity.isLocalPlayer) {
			return;
		}

        if (anim.isPlaying == false)
        {
            if (Input.GetKeyDown("q"))
            {
                Debug.Log("Playing Left Hand Swat Animation");
				anim.CrossFade("Swat_Left", 0.5f, PlayMode.StopAll);
            }
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("Playing Right Hand Swat Animation");
				anim.CrossFade("Swat_Right", 0.5f, PlayMode.StopAll);
            }
            if (Input.GetKeyDown("q") && Input.GetKeyDown("e"))
            {
                Debug.Log("Playing Both Hand Swat Animation");
				anim.CrossFade("Swat_Both", 0.5f, PlayMode.StopAll);
            }
        }

	}
}
