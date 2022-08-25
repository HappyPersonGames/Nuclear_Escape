using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    private bool alert;
    private bool up;
    private GameObject player;
    [SerializeField]
    private float alertRange;
    
    // Start is called before the first frame update
    void Start()
    {
        alert = false;
        up = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        alert = Mathf.Abs(Vector3.Distance(player.transform.position, transform.position)) <= alertRange;

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
        alert = true;
        up = true;
    }

}
