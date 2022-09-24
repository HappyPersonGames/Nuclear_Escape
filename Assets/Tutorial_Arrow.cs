using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Arrow : MonoBehaviour
{
    [SerializeField]
    private GameObject arrow1;
    [SerializeField]
    private GameObject arrow2;
    [SerializeField]
    private GameObject arrow3;
    [SerializeField]
    private GameObject arrow4;
    [SerializeField]
    private GameObject arrow_container;
    [SerializeField]
    private GameObject arrow_door;
    [SerializeField]
    private GameObject stick1;
    [SerializeField]
    private GameObject stick2;
    [SerializeField]
    private GameObject stick3;
    [SerializeField]
    private GameObject stick4;
    [SerializeField]
    private GameObject container;
    private bool all_sticks_taken;
    // Start is called before the first frame update
    void Start()
    {
        arrow_container.SetActive(false);
        arrow_door.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(stick1 == null && arrow1 != null)
        {
            Destroy(arrow1);
        }
        if(stick2 == null && arrow2 != null)
        {
            Destroy(arrow2);
        }
        if(stick3 == null && arrow3 != null)
        {
            Destroy(arrow3);
        }
        if(stick4 == null && arrow4 != null)
        {
            Destroy(arrow4);
        }
        if(stick1 == null && stick2 == null && stick3 == null && stick4 == null)
        {
            all_sticks_taken = true;
        }
        if(all_sticks_taken || GetComponent<gather>().getCurrentCapacity() == 3)
        {
            arrow_container.SetActive(true);
        }
        else
        {
            arrow_container.SetActive(false);
        }
        if(container.GetComponent<container>().getCurrent() == container.GetComponent<container>().getTargetAmount())
        {
            arrow_container.SetActive(false);
            arrow_door.SetActive(true);
        }
    }
}
