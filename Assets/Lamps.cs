using UnityEngine;
using System.Collections;

public class Lamps : MonoBehaviour {

	Vector3 originalPosition;
	bool hasTurnedOff = false;

	void Start()
    { 
		originalPosition = transform.position;
	}

	void Update()
    {

		if (hasTurnedOff)
        {
			return;
		}
        else if (Vector3.Distance (originalPosition, transform.position) > 30)
        {
            StartCoroutine(FlickerOff());
        }

	}

    IEnumerator FlickerOff()
    {
        hasTurnedOff = true;
        transform.GetComponentInChildren<Light>().enabled = false;
        transform.FindChild("lamp1").GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        yield return new WaitForSeconds(.4f);
        transform.GetComponentInChildren<Light>().enabled = true;
        transform.FindChild("lamp1").GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        yield return new WaitForSeconds(.2f);
        transform.GetComponentInChildren<Light>().enabled = false;
        transform.FindChild("lamp1").GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        yield return new WaitForSeconds(.2f);
        transform.GetComponentInChildren<Light>().enabled = true;
        transform.FindChild("lamp1").GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        yield return new WaitForSeconds(.2f);
        transform.GetComponentInChildren<Light>().enabled = false;
        transform.FindChild("lamp1").GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
    }

}
