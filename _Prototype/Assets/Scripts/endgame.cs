using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endgame : MonoBehaviour
{
    public AudioClip endsound;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().clip = endsound;            //when the object becomes active the background music should change to ending music
        GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().Play();             //and play
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)               //the next time the player presses any key
        {
            Cursor.lockState = CursorLockMode.None;         //the mouse should be unlocked from the middle
            SceneManager.LoadScene("Start_Screen",LoadSceneMode.Single);            //and escape back to start screen
        }
    }
}
