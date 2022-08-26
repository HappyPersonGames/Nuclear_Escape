using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class enemy1 : MonoBehaviour
{
    private bool alert;
    private bool up;
    private GameObject player;
    [SerializeField]
    private float alertRange;
    private SpriteRenderer sr;
    [SerializeField]
    private Sprite awake;
    [SerializeField]
    private Sprite asleep;
    private Light2D mLight;
    
    // Start is called before the first frame update
    void Start()
    {
        alert = false;
        up = false;
        player = GameObject.FindGameObjectWithTag("Player");
        sr = GetComponentInChildren<SpriteRenderer>();
        mLight = GetComponentInChildren<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        alert = Mathf.Abs(Vector3.Distance(player.transform.position, transform.position)) <= player.GetComponent<gather>().getAlertRadius();

        if (alert)
        {
            wakeUp();
        }

        else
        {
            pauseAttack();    
        }
        if (!up)
        {
            mLight.pointLightInnerRadius = 0;
            mLight.pointLightOuterRadius = 0;
        }


    }

    public String getState()
    {
        if (alert)
            return "Alert";
        if (up)
            return "Wait";
        return "Sleep";
    }

    public void wakeUp()
    {
        up = true;
        sr.sprite = awake;
        mLight.pointLightInnerRadius = 0;
        mLight.pointLightOuterRadius = 3;
    }

    public void pauseAttack()
    {
        sr.sprite = asleep;
        if(up) 
        {
            
        }
    }

}
