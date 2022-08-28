using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class loadGame : MonoBehaviour
{
    private Light2D light2D;
    private bool flag;
    void Start()
    {
        light2D = GetComponentInChildren<Light2D>();
        flag = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Jump"))
        {
            flag = true;
        }
        if(flag)
        {
            light2D.intensity -= 0.001f;
            if(light2D.intensity <= 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
