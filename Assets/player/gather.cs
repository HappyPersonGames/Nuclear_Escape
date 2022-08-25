using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class gather : MonoBehaviour
{
    private float alertRadius;
    private CircleCollider2D grabRadius;
    private Light2D playerLight;
    private float initRadius = 0.3f;
    [SerializeField]
    private int capacity = 3;
    [SerializeField]
    private int current = 0;
    [SerializeField]
    private float lightMult = 1.5f;
    [SerializeField]
    private Sprite s0;
    [SerializeField]
    private Sprite s1;
    [SerializeField]
    private Sprite s2;
    [SerializeField]
    private Sprite s3;
    private SpriteRenderer sr;
    private bool dep;
    private Collider2D container;
    
    
    // Start is called before the first frame update
    void Start()
    {
        grabRadius = GetComponent<CircleCollider2D>();
        current = 0;
        playerLight = GetComponentInChildren<Light2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        changeSprite();
        container = GameObject.FindGameObjectWithTag("container").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // light manage
        playerLight.pointLightInnerRadius = initRadius * (current+1) * lightMult;
        playerLight.pointLightOuterRadius = initRadius * (current+3) * lightMult;
        alertRadius = playerLight.pointLightInnerRadius;
        dep = Input.GetButton("Jump");
        
        if(grabRadius.IsTouching(container) && container.CompareTag("container"))
        {
            if(dep && current > 0)    
            {
                current--;
                changeSprite();
                container.GetComponent<container>().addMore();
            }
        }
        
    }

    private void changeSprite()
    {
        // change Sprite
        if (current == 0)
            sr.sprite = s0;
        else if (current == 1)
            sr.sprite = s1;
        else if (current == 2)
            sr.sprite = s2;
        else if (current == 3)
            sr.sprite = s3;
        else 
            sr.sprite = s0;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(grabRadius.IsTouching(other) && other.CompareTag("sticklight"))
        {
            if (current < capacity)
            {
                current ++;
                Destroy(other.gameObject);
                changeSprite();
            }
            
        }
        
    }
    public float getAlertRadius()
    {
        return alertRadius;
    }


}
