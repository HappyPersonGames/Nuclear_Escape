using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : action
{
    private Collider2D player;
    private BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        bc = GetComponent<BoxCollider2D>();
        bc.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(bc.isTrigger && bc.IsTouching(player))
        {
            nextLevel();    
        }
    }

    public override void activate()
    {
        AudioSource asa = GetComponent<AudioSource>();
        asa.mute = false;
        asa.Play();
        
        bc.isTrigger = true;

    }

    private void nextLevel()
    {
        Debug.Log("you won!");
    }
}
