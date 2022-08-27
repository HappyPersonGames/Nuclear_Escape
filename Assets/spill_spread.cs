using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class spill_spread : action
{
    private bool start_spreading = false;
    private bool t = true;
    [SerializeField]
    private float growingBy = 1f;
    
    public float i;

    // Update is called once per frame
    void FixedUpdate()
    {
        i = GetComponentInChildren<Light2D>().intensity;
        if (start_spreading && t)
        {
            t = false;
            growingBy *= 3;
        }
        transform.localScale += new Vector3(growingBy, growingBy, growingBy);
        GetComponentInChildren<Light2D>().pointLightOuterRadius += growingBy;
        // GetComponentInChildren<Light2D>().pointLightInnerRadius += growingBy;
        if(i < 1.5)
            GetComponentInChildren<Light2D>().intensity += growingBy;
        // t = Time.fixedTime;
        
    }

    public override void activate()
    {
        start_spreading = true;
    }
}
