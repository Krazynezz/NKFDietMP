using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestroy : MonoBehaviour
{
    AudioClip startingclip;
    private static NoDestroy gameInstance;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<AudioSource>().clip = startingclip; // This assigns the audio clip at the start menu
        DontDestroyOnLoad(this.gameObject); // This will prevent the music object from being destroyed upon loading into another scene

        if (gameInstance == null) // This will prevent the BGM from playing twice upon loading back to the start menu screen
        {
            gameInstance = this;
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
