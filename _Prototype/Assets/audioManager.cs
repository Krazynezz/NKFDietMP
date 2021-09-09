using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera" && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
