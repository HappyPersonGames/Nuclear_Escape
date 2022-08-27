using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_enemy : action
{
    [SerializeField]
    private GameObject enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void activate()
    {
        float ft = Time.fixedTime;
        GameObject spawned = Instantiate(enemy,transform.position,Quaternion.identity);
        
        spawned.GetComponent<enemy1>().forceIdle();
        
        spawned.GetComponent<enemy1>().unforceIdle();
    }
}
