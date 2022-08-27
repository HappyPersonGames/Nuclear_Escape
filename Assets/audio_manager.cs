using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_manager : MonoBehaviour
{
    private AudioSource chase;
    private AudioSource def_track;
    private bool isChase;
    private bool locked;
    private float t;
    // Start is called before the first frame update
    void Start()
    {
        chase = GameObject.FindGameObjectWithTag("chase").GetComponent<AudioSource>();
        def_track = GameObject.FindGameObjectWithTag("def").GetComponent<AudioSource>();
        isChase = false;
        locked = false;
        t = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        if(Time.fixedTime - t > 0.5f && chase.volume > 0)
        {
            t = Time.fixedTime;
            chase.volume -= 0.1f;
            if(def_track.volume < 1)
                def_track.volume += 0.2f;
        }
        
    }

    public void chasing()
    {
        if(!locked)
        {
            locked = true;
            chase.volume = 1;
            def_track.volume = 0.2f;
            isChase = true;
            locked = false;
        }
    }
}
