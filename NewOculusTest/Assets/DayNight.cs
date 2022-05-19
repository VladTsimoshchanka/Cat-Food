using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    [Range( 0.0f, 1.0f)]
    public float time;
    public float fullDayLength;
    public float startTime = 0.5f;
    public float timeRate;
    public Vector3 noon;

    public Light Sun;
    public Gradient sunColor;
    public AnimationCurve sunIntensity;

    public Light Moon;
    public Gradient moonColor;
    public AnimationCurve moonIntensity;

    public AnimationCurve lightingIntensityMultiplier;
    public AnimationCurve reflectionIntensityMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        timeRate = 1.0f / fullDayLength;
        time = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        time += timeRate * Time.deltaTime;
        if(time >= 1.0f)
        {
            time = 0.0f;
        }
        Sun.transform.eulerAngles = (time - 0.25f) * noon * 4.0f;
        Moon.transform.eulerAngles = (time - 0.75f) * noon * 4.0f;

        Sun.intensity = sunIntensity.Evaluate(time);
        Moon.intensity = moonIntensity.Evaluate(time);

        Sun.color = sunColor.Evaluate(time);
        Moon.color = moonColor.Evaluate(time);

        if(Sun.intensity == 0 && Sun.gameObject.activeInHierarchy)
        {
            Sun.gameObject.SetActive(false);
        }
        else if (Sun.intensity > 0 && !Sun.gameObject.activeInHierarchy)
        {
            Sun.gameObject.SetActive(true);
        }

        if (Moon.intensity == 0 && Moon.gameObject.activeInHierarchy)
        {
            Moon.gameObject.SetActive(false);
        }
        else if (Moon.intensity > 0 && !Moon.gameObject.activeInHierarchy)
        {
            Moon.gameObject.SetActive(true);
        }

        RenderSettings.ambientIntensity = lightingIntensityMultiplier.Evaluate(time);
        RenderSettings.reflectionIntensity = reflectionIntensityMultiplier.Evaluate(time);

    }
}
