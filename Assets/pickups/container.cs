using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class container : MonoBehaviour
{
    private Light2D cLight;
    private float initRadius = 0.5f;
    [SerializeField]
    private int capacity = 999;
    [SerializeField]
    private int current = 0;
    [SerializeField]
    private int targetAmount = 4;
    [SerializeField]
    private float lightMult = 1.1f;

    [SerializeField]
    private Sprite s0;
    [SerializeField]
    private Sprite s1;
    [SerializeField]
    private Sprite s2;
    [SerializeField]
    private Sprite s3;
    private SpriteRenderer sr;
    private GameObject[] actionsOnFull;
    private GameObject[] actionsOnFirst;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        cLight = GetComponentInChildren<Light2D>();
        targetAmount = GameObject.FindGameObjectsWithTag("sticklight").Length;
        sr = GetComponentInChildren<SpriteRenderer>();
        changeSprite();
        actionsOnFull = GameObject.FindGameObjectsWithTag("full_action");
        actionsOnFirst = GameObject.FindGameObjectsWithTag("first_action");
    }

    // Update is called once per frame
    void Update()
    {
        // light manage
        cLight.pointLightInnerRadius = initRadius * (current);
        cLight.pointLightOuterRadius = initRadius * (current) * lightMult;
    }

    private void openDoor()
    {

    }

    private void changeSprite()
    {
        float cur = current;
        float cap = targetAmount;
        float press = cur/cap;

        // change Sprite
        if (press >= 1f)
        {
            sr.sprite = s3;
        }
        else if (press >= 0.6f)
            sr.sprite = s2;
        else if (press >= 0.01f)
            sr.sprite = s1;
        else 
            sr.sprite = s0;
    }

    public void addMore()
    {
        if (current == 0)
        {
            foreach (GameObject a in actionsOnFirst)
            {

                a.GetComponent<action>().activate();
            }
        }
        current++;
        changeSprite();
        if (current == targetAmount)
        {
            foreach (GameObject a in actionsOnFull)
            {
                a.GetComponent<action>().activate();
            }
        }
    }

    public void unlock()
    {

    }
}
