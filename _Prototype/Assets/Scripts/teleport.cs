using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    float fading;
    Color tempcolor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inside == true)             //if the player is in the teleporter cylinder
        {
            counttime += Time.deltaTime;        //a timer starts to count up
        }
        if (endingeffect.activeInHierarchy == false && triggered2 == false)         //if the kidney and ending screen has not spawned yet
        {
            Instantiate(kidneys, endingeffect.transform.position,Quaternion.identity);          //the attached kidney hologram model will be spawned
            triggered2 = true;                                      //once inly
        }
        if (triggered2 == true) 
        {
            delay += Time.deltaTime;                //and another timer starts to count up
        }
        if (delay >= 1)             //to delay the ending screen from appearing by 1 second
        {
            tempcolor = endscreen.GetComponentInChildren<Image>().color;            //get the current color of the background
            tempcolor.a = fading;                           //and the tranparency of the background
            endscreen.GetComponentInChildren<Image>().color = tempcolor;            //sets the background color to the next version
            endscreen.SetActive(true);                  //the endscreen will start to appear
            fading += 0.001f;                   //and the endscreen starts to fade in
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")          //if the object that collides with the teleporter cylinder is the player
        {
            inside = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(counttime >= 3 && triggered == false)            //if the player has stayed in the teleporter for 3 seconds
        {
            player.GetComponent<move>().enabled = false;        //stops thee player from moving
            player.transform.position = this.transform.position + Vector3.up;           //moves the player into postion
            player.transform.LookAt(endingeffect.transform, Vector3.up);            //make the player look at the ending effect
            endingeffect.GetComponent<particlemanager>().playparticle();            //starts playing the particle effect
            triggered = true;           //and prevent the code from playing again

        }
    }
    private void OnTriggerExit(Collider other)              //if the player leaves before 3 seconds
    {
        inside = false;         //he is no longer inside the teleporter cylinder
        counttime = 0;          //so the timer resets
    }
}
