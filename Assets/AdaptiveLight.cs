using UnityEngine;
using System.Collections;

public class AdaptiveLight : MonoBehaviour {

	void Start()
	{
		StartCoroutine(TickLight ());
	}

	IEnumerator TickLight()
	{
		yield return new WaitForSeconds (.1f);
		RenderSettings.ambientIntensity += .001f;
		StartCoroutine(TickLight ());
	}

}
