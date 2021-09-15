using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera" && this.gameObject.GetComponent<AudioSource>().clip != null)
        {
            other.GetComponent<AudioSource>().clip = this.gameObject.GetComponent<AudioSource>().clip;
            other.GetComponent<AudioSource>().Play();
            this.gameObject.GetComponent<AudioSource>().clip = null;
        }
    }
}
