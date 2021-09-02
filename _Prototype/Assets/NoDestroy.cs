using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestroy : MonoBehaviour
{
    private static NoDestroy gameInstance;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject); // This will prevent the music object from being destroyed upon loading into another scene

        if (gameInstance == null) // This will prevent the BGM from playing twice upon loading back to the start menu screen
        {
            gameInstance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }
}
