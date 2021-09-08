using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorSound : MonoBehaviour
{
    public Placement2 placement2;
    bool audioPlayed = false;
    public AudioSource doorAudio;

    void Update()
    {
        if (placement2.doorOpen == true && audioPlayed == false)
        {
            doorAudio.Play();
        }
    }
}
