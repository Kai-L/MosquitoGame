using UnityEngine;
using System.Collections;

public class Lightswitch : MonoBehaviour {

	public Light lightToSwitch;
	public GameObject lightSwitch;
	public bool lightActive;

    public int yRotationAdjust;

    bool canTurn = true;

    void Start()
    {
        lightToSwitch.enabled = lightActive;
    }

    void OnTriggerEnter(Collider c)
	{
        if (c.tag == "Player" || c.tag == "mosquito" && canTurn)
        {
            lightActive = !lightActive;
            lightToSwitch.enabled = lightActive;
            Vector3 tempRot;
            tempRot = lightSwitch.transform.eulerAngles;
            tempRot.x = 0;
            tempRot.y = yRotationAdjust;
            tempRot.z += 180;
            lightSwitch.transform.eulerAngles = tempRot;
            StartCoroutine(LightTimer());
        }
    }

    IEnumerator LightTimer()
    {
        canTurn = false;
        yield return new WaitForSeconds(3);
        canTurn = true;
    }
}
