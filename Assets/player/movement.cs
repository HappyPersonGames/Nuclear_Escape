using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb2;
    private float horizontal_movement;
    private float vertical_movement;
    [SerializeField]
    private float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal_movement = Input.GetAxisRaw("Horizontal");
        vertical_movement = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {
        if(GetComponent<gather>().getHealth() > 0)
        {
            if(horizontal_movement != 0 && vertical_movement != 0 )
                rb2.velocity = new Vector2(horizontal_movement * 3, vertical_movement * 3);
            else
                rb2.velocity = new Vector2(horizontal_movement * speed, vertical_movement * speed);
            if(horizontal_movement < 0)
            {
                this.gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
                
            }
            else if(horizontal_movement > 0)
            {
                this.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }

}
