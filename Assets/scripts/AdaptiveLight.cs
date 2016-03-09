using UnityEngine;
using System.Collections;

public class AdaptiveLight : MonoBehaviour {

	//public float rateOfChange = .1f;

	public float currentTime = 0;

	public Light directionalLight;

	public Color nightColor = new Color(39, 55, 90);
	public float nightIntensity = 0.58f;

	public Color dawnColor = new Color (255, 255, 191);
	public float dawnIntensity = 0.75f;

	public Color endColor = new Color (255, 249, 154);
	public float endIntensity = 1.53f;

	public int dawnTime = 240;
	public int endTime = 360;

	Clock clock;

	bool dawnHasCome = false;

	void Start()
	{
		directionalLight = this.GetComponent<Light>();

		clock = FindObjectOfType<Clock> ();

		directionalLight.color = nightColor;
		directionalLight.intensity = nightIntensity;

		//StartCoroutine(TickLight ());
	}
		
	void Update()
	{
		currentTime = clock.totalSeconds;

		if (!dawnHasCome) 
		{
			directionalLight.color = Color.Lerp (directionalLight.color, dawnColor, currentTime / dawnTime);
			directionalLight.intensity = Mathf.Lerp (directionalLight.intensity, dawnIntensity, currentTime / dawnTime);
		} 
		else 
		{
			directionalLight.color = Color.Lerp (directionalLight.color, endColor, currentTime / endTime);
			directionalLight.intensity = Mathf.Lerp (directionalLight.intensity, endIntensity, currentTime / endTime);
		}
		if (currentTime == dawnTime) {
			dawnHasCome = true;
		}
	}

	/*
	IEnumerator TickLight()
	{
		yield return new WaitForSeconds (rateOfChange);
		RenderSettings.ambientIntensity += .001f;
		//StartCoroutine(TickLight ());
	}
	*/ 
}
