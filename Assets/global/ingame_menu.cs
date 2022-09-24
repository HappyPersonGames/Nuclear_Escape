using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class ingame_menu : MonoBehaviour
{
    private Light2D light2D;
    private float startFadeTime;
    private float fadeInTime = 0.1f;
    private float fadeoutTime = 2f;
    private float baseIntensity = 0.7f;
    void Start()
    {
        light2D = GetComponentInChildren<Light2D>();
        startFadeTime = -1;
        light2D.intensity = 0f;
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if(startFadeTime != -1)
        {
            light2D.intensity = calc_intens(Time.timeSinceLevelLoad - startFadeTime);
            if(Input.GetButtonDown("Cancel") || light2D.intensity <= 0)
            {
                startFadeTime = -1;
                light2D.intensity = 0f;
            }
            if(Input.GetButtonDown("Quit"))
            {
                Debug.Log("exit game");
                Application.Quit();
            }
        }
        else if(Input.GetButtonDown("Cancel"))
        {
            startFadeTime = Time.timeSinceLevelLoad;
        }
    }

    float calc_intens(float time_passed)
    {
        if (time_passed <= fadeInTime)
        {
            return baseIntensity * ((time_passed)/(fadeInTime));
        }
        else
        {
            return baseIntensity - baseIntensity * ((time_passed)/(fadeoutTime + fadeInTime));
        }
    }
}
