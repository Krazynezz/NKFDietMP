using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioSource entranceAudio;
    //public AudioSource doorAudio;
    //public Placement2 placement2;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera" && !entranceAudio.isPlaying)
        {
            entranceAudio.Play();
        }
    }

   /*
    void Update()
    {
        if (placement2.done == true)
        {
            doorAudio.Play();
        }
    }

    void playDoorSound2()
    {
        doorAudio.Play();
    }
   */
}
