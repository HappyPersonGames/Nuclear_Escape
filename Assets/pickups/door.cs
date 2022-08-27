using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : action
{
    private Collider2D player;
    private BoxCollider2D bc;
    private Animator anim;
    private float curTime;
    private bool finished;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        bc = GetComponent<BoxCollider2D>();
        bc.isTrigger = false;
        anim = GetComponentInChildren<Animator>();
        finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(curTime >= Time.deltaTime + 2 && finished)
        {
            bc.isTrigger = true;
            curTime = Time.fixedTime;
        }
        else if(bc.isTrigger && bc.IsTouching(player) && curTime >= Time.deltaTime + 2)
        {
            nextLevel();
        }
    }

    public override void activate()
    {
        anim.SetBool("exit", true);
        AudioSource asa = GetComponent<AudioSource>();
        asa.mute = false;
        asa.Play();
        finished = true;
        curTime = Time.fixedTime;
    }

    private void nextLevel()
    {
        anim.SetBool("exit", false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
