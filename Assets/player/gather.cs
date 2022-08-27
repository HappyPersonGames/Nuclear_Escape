using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    private Animator anim;
    private bool dep;
    private Collider2D container;
    [SerializeField]
    private int health = 3;
    [SerializeField]
    private int GRACE_PERIOD = 3;
    private int MAX_HEALTH;
    private int coolDownAttack;
    private float coolDownLight;
    private float time;
    private float deathTime;
    private Color originalPlayer;
    private AudioSource asa;
    [SerializeField]
    private GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        grabRadius = GetComponent<CircleCollider2D>();
        current = 0;
        playerLight = GetComponentInChildren<Light2D>();
        container = GameObject.FindGameObjectWithTag("container").GetComponent<Collider2D>();
        time = Time.fixedTime;
        MAX_HEALTH = health;
        originalPlayer = playerLight.color;
        asa = GetComponent<AudioSource>();
        anim = GetComponentInChildren<Animator>();
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(health <= 0 && health > -44)
        {
            killPlayer();
        }
        // light manage
        playerLight.pointLightInnerRadius = initRadius * (current+1) * lightMult;
        playerLight.pointLightOuterRadius = initRadius * (current+3) * lightMult;
        alertRadius = playerLight.pointLightOuterRadius;
        dep = Input.GetButton("Jump");
        if (health <= -44 && dep)
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
           gameObject.SetActive(false);
        }
        lightFlicker();
        if(grabRadius.IsTouching(container) && container.CompareTag("container"))
        {
            if(dep && current > 0)    
            {
                container.GetComponent<container>().addMore(current);
                current = 0;
                anim.SetInteger("current", current);
            }
        }
        if(Time.fixedTime - time > 1)
        {
            deathTime++;
            time = Time.fixedTime;
            if(health <= 0 && deathTime > 3)
                gameOver.SetActive(true);
            else if (coolDownAttack > 0)
            {
                playerLight.color = Color.Lerp(originalPlayer, Color.red, (coolDownAttack + 0f)/GRACE_PERIOD);
                coolDownAttack--;
            }
            else
            {
                playerLight.color = originalPlayer;
            }
        }
    }

    public void lightFlicker()
    {
        if ((Time.fixedTime) % health == 0 && health != MAX_HEALTH)
            playerLight.intensity = 0;
        else
            playerLight.intensity = 1;
    }

    public void killPlayer()
    {
        anim.SetInteger("hp", health);
        playerLight.color = Color.red;
        health = -44;
        deathTime = 0;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(grabRadius.IsTouching(other) && other.CompareTag("sticklight"))
        {
            if (current < capacity)
            {
                asa.mute = false;
                asa.Play();
                current ++;
                anim.SetInteger("current", current);
                Destroy(other.gameObject);
            }
            
        }
        
    }
    public float getAlertRadius()
    {
        return alertRadius + getLevelMod();
    }

    public void doDamage()
    {
        if(coolDownAttack == 0)
        {
            playerLight.color = Color.red;
            health--;
            coolDownAttack = GRACE_PERIOD;
            Transform cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
            cam.GetComponent<Shake>().shakeDuration = 0.4f;
            
        }
        
    }

    public int getHealth()
    {
        return health;
    }

    private float getLevelMod()
    {
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            return 5;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            return 3;
        }
        else
        {
            return 0;
        }
    }

    public bool isImmune()
    {
        return coolDownAttack != 0;
    }

}
