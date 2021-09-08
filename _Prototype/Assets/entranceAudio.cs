using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entranceAudio : MonoBehaviour
{
    public AudioSource entranceSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera" && !entranceSound.isPlaying)
        {
            entranceSound.Play();
        }
    }
}
