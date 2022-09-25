using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class loadGame : MonoBehaviour
{
    private Light2D light2D;
    private float startFadeTime;
    private float fadeoutTime = 2.5f;
    private float baseIntensity;
    private bool pressed;

    void Start()
    {
        light2D = GetComponentInChildren<Light2D>();
        startFadeTime = -1;
        baseIntensity = light2D.intensity;
        pressed = false;
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Jump") && pressed == false)
        {
            startFadeTime = Time.timeSinceLevelLoad;
            pressed = true;
        }
        if(startFadeTime > 0)
        {
            light2D.intensity = baseIntensity - baseIntensity * ((Time.timeSinceLevelLoad - startFadeTime)/fadeoutTime);
            if(light2D.intensity <= 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
