using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {

    public TextMesh text;

    public int startingHour;
    public int startingMinutes;

    public int endingHour;
    public int endingMinutes;

    public int currentHour;
    public int currentMinute;

    public float rateOfTime;

    void Start()
    {
        currentHour = startingHour;
        currentMinute = startingMinutes;
        text.text = startingHour.ToString("00") + ":" + startingMinutes.ToString("00");
        StartCoroutine(TickSecond());
    }

	IEnumerator TickSecond()
    {
        currentMinute += 1;
        if(currentMinute == 60)
        {
            currentMinute = 0;
            currentHour += 1;
        }
        if(currentHour == 13)
        {
            currentHour = 1;
        }
        if(currentHour == endingHour)
        {
            Debug.LogWarning("Morning Has Come");
            yield break;
        }
        text.text = currentHour.ToString("00") + ":" + currentMinute.ToString("00");
        yield return new WaitForSeconds(rateOfTime);
        StartCoroutine(TickSecond());
    }
}
