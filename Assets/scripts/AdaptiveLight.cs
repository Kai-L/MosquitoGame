using UnityEngine;
using System.Collections;

public class AdaptiveLight : MonoBehaviour {

	//public float rateOfChange = .1f;

	public float currentTime = 0;

	public Light directionalLight;

	public Color nightColor = new Color(39, 55, 90);
	public float nightIntensity = 1.36f;

	public Color nightAmbient = new Color(39,43, 135);
	public float nightAmbientIntensity =.52f;

	public Color dawnColor = new Color (255, 255, 191);
	public float dawnIntensity = 0.75f;

	public Color dawnAmbient = new Color(163, 165, 52);
	public float dawnAmbientIntesntiy =2.33f;

	//public Color endColor = new Color (255, 249, 154);
	//public float endIntensity = 1.53f;

	public int dawnTime = 180000;
	//public int endTime = 360;

	Clock clock;

	bool dawnHasCome = false;

	void Start()
	{
		directionalLight = this.GetComponent<Light>();

		clock = FindObjectOfType<Clock> ();

		directionalLight.color = nightColor;
		directionalLight.intensity = nightIntensity;
		RenderSettings.ambientLight = nightAmbient;
		RenderSettings.ambientIntensity = nightAmbientIntensity;


		//StartCoroutine(TickLight ());
	}
		
	void Update()
	{
		currentTime = clock.totalSeconds;

		if (!dawnHasCome) 
		{
			directionalLight.color = Color.Lerp (directionalLight.color, dawnColor, currentTime / dawnTime);
			directionalLight.intensity = Mathf.Lerp (directionalLight.intensity, dawnIntensity, currentTime / dawnTime);
			RenderSettings.ambientLight = Color.Lerp (RenderSettings.ambientLight, dawnAmbient, currentTime / dawnTime);
			RenderSettings.ambientIntensity = Mathf.Lerp (RenderSettings.ambientIntensity, dawnAmbientIntesntiy, currentTime / dawnTime);
		} 
		else 
		{
			directionalLight.color = Color.Lerp (directionalLight.color, nightColor, currentTime / dawnTime);
			directionalLight.intensity = Mathf.Lerp (directionalLight.intensity, nightIntensity, currentTime / dawnTime);
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
