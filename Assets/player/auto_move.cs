using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auto_move : MonoBehaviour
{
    private float wtime = 5;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(3f,0);
        wtime = Time.fixedTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.fixedTime > wtime + 5 && Time.fixedTime < wtime + 10)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>()
            .orthographicSize += 0.1f; 
        }

        if(Time.fixedTime > wtime + 15)
            Application.Quit();
        
    }
    
}
