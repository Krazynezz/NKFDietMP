using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    float counttime;
    bool inside = false;
    public GameObject player;
    public GameObject endingeffect;
    bool triggered = false;
    public GameObject kidneys;
    bool triggered2 = false;
    public GameObject endscreen;
    float delay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inside == true)
        {
            counttime += Time.deltaTime;
        }
        if (endingeffect.activeInHierarchy == false && triggered2 == false)
        {
            Instantiate(kidneys, this.transform, true);
            triggered2 = true;
            delay += Time.deltaTime;
        }
        if(delay >= 1)
        {
            endscreen.active = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            inside = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(counttime >= 3 && triggered == false)
        {
            player.GetComponent<move>().enabled = false;
            player.transform.position = this.transform.position + Vector3.up;
            player.transform.LookAt(endingeffect.transform, Vector3.up);
            endingeffect.GetComponent<particlemanager>().playparticle();
            triggered = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        inside = false;
        counttime = 0;
    }
}
