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
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        bc = GetComponent<BoxCollider2D>();
        bc.isTrigger = false;
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bc.isTrigger && bc.IsTouching(player) && Time.fixedTime >= curTime + 2)
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
        bc.isTrigger = true;
        curTime = Time.fixedTime;
    }

    private void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
