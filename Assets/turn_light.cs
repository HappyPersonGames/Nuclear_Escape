using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class turn_light : action
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void activate()
    {
        GetComponent<Light2D>().pointLightOuterRadius = 3f;
    }
}
