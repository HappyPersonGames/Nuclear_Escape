using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 200f; 
    public GameObject target;
    
    private Vector2 last_pos;
    public float jump_cooldown = 0.2f;
    public float last_jump;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        last_jump = Time.fixedTime;
    }
    // Update is called once per frame
    void Update()
    {
        
        find_target();
        rb.velocity =   (target.transform.position - transform.position);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            
        
        
        if(rb.velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        else if(rb.velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        
        
    }

    public void find_target()
    {
        float smallest = 9999f;
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Player"))
        {
            if(Mathf.Abs(Vector3.Distance(item.transform.position, transform.position)) < smallest)
            {
                smallest = Mathf.Abs(Vector3.Distance(item.transform.position, transform.position));
                target = item;
            }
        }
    }

}
