using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class spill_spread : action
{
    private bool start_spreading = true;
    private float t;
    [SerializeField]
    private float growingBy = 1f;
    // Start is called before the first frame update
    void Start()
    {
        t = Time.fixedTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (start_spreading)
        {
            transform.localScale += new Vector3(growingBy, growingBy, growingBy);
            GetComponentInChildren<Light2D>().pointLightOuterRadius += growingBy;
            GetComponentInChildren<Light2D>().pointLightInnerRadius += growingBy;
            // t = Time.fixedTime;
        }
    }

    public override void activate()
    {
        start_spreading = true;
    }
}
