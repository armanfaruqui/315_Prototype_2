using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    private float timeMultiplier;
    
    [SerializeField]
    private float startHour;

    [SerializeField]
    private TextMeshProUGUI timeText;

    [SerializeField]
    private Light sunLight;

    [SerializeField]
    private float sunriseHour;

    [SerializeField]
    private float sunsetHour;

    [SerializeField]
    private Color dayAmbientLight;

    [SerializeField]
    private Color nightAmbientLight;

    [SerializeField]
    private AnimationCurve lightChangeCurve;

    [SerializeField]
    private float maxSunLightIntensity;

    [SerializeField]
    private Light moonLight;

    [SerializeField]
    private float maxMoonLightIntensity;

    [SerializeField]
    public float speed;

    private DateTime currentTime;

    private TimeSpan sunriseTime;

    private TimeSpan sunsetTime;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);

        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);

    }

    private void Update()
    {
        ControlTime();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateTimeofDay();
        RotateSun();
        UpdateLightSettings();
    }

    //Increases current time
    private void UpdateTimeofDay()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);
        // Checks if text field is null. If it isnt, text set to current time
        if (timeText != null)
        {
            timeText.text = currentTime.ToString("HH:mm");
        }
    }

    // Rotates sun to change the time of day in the scene
    private void RotateSun()
    {
        float sunLightRotation;

        if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime)
        {
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(sunriseTime, sunsetTime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(0, 180, (float)percentage);
        }
        else
        {
            TimeSpan sunsetToSunRiseDuration = CalculateTimeDifference(sunsetTime, sunriseTime);
            TimeSpan timeSinceSunset = CalculateTimeDifference(sunsetTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunRiseDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(180, 360, (float)percentage);

        }
        sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right);
    }

    private void UpdateLightSettings()
    {
        float dotProduct = Vector3.Dot(sunLight.transform.forward, Vector3.down);
        sunLight.intensity = Mathf.Lerp(0, maxSunLightIntensity, lightChangeCurve.Evaluate(dotProduct));
        moonLight.intensity = Mathf.Lerp(maxMoonLightIntensity, 0, lightChangeCurve.Evaluate(dotProduct));
        RenderSettings.ambientLight = Color.Lerp(nightAmbientLight, dayAmbientLight, lightChangeCurve.Evaluate(dotProduct));
    }

    private void ControlTime()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (timeMultiplier < 6000)
            {
                timeMultiplier += speed;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (timeMultiplier > -6000)
            {
                timeMultiplier -= speed;
            }
        }
    }

    // Calculates the difference between times to determine how long it is untul sunrise/suneset
    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;

        if (difference.TotalSeconds < 0)
        {
            difference += TimeSpan.FromHours(24);
        }

        return difference;
    }
}
