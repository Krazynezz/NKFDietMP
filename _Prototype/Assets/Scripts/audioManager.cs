using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera" && this.gameObject.GetComponent<AudioSource>().clip != null)          //when the player moves into one of the trigger areas
        {
            other.GetComponent<AudioSource>().clip = this.gameObject.GetComponent<AudioSource>().clip;          //the current audio clip will be cut off and replaced with the one attached to this object
            other.GetComponent<AudioSource>().Play();                           //and start plaing  
            this.gameObject.GetComponent<AudioSource>().clip = null;            //and the clip attached to this object will be removed to prevent it from playing again if triggered again
        }
    }
}
