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
    private float attackRange = 1;
    private Animator anim;
    private Light2D mLight;
    
    private bool attack;
    private bool idle;
    private AudioSource hit;
    private audio_manager am;
    
    // Start is called before the first frame update
    void Start()
    {
        alert = false;
        up = false;
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInChildren<Animator>();
        mLight = GetComponentInChildren<Light2D>();
        attack = false;
        idle = false;
        hit = GetComponent<AudioSource>();
        am = GameObject.FindGameObjectWithTag("chase").GetComponentInParent<audio_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        alert = Mathf.Abs(Vector3.Distance(player.transform.position, transform.position)) <= player.GetComponent<gather>().getAlertRadius();
        attack = Mathf.Abs(Vector3.Distance(player.transform.position, transform.position)) <= attackRange && !idle;
        if (alert)
        {
            wakeUp();
            am.chasing();
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
        if(attack)
        {
            hit.mute = false;
            hit.Play();
            player.GetComponent<gather>().doDamage();
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
        mLight.pointLightOuterRadius = 3;
        anim.SetBool("idle",false);
    }

    public void pauseAttack()
    {
        anim.SetBool("idle",true);
        if(up) 
        {
            if(mLight.pointLightOuterRadius > 0)
            {
                mLight.pointLightOuterRadius -= 0.02f;
            }
            else
            {
                up = false;
            }
        }
    }

    public void forceIdle()
    {
        idle = true;
    }

    public void unforceIdle()
    {
        idle = false;
    }
}
