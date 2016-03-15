using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

    bool loadingOff = false;

	void Update()
    {
        if (loadingOff)
        {
            return;
        }

        if(FindObjectOfType<Camera>() != null)
        {
            gameObject.SetActive(false);
            loadingOff = true;
        }
    }

}
