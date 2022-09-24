using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acid : MonoBehaviour
{
    private GameObject player;
    private bool attack;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        attack = GetComponent<Collider2D>().IsTouching(player.GetComponent<CapsuleCollider2D>());
        if(attack)
        {
            player.GetComponent<gather>().doDamage();
        }
    }
}
