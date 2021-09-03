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
        GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>().clip = endsound;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            this.gameObject.active = false;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Start_Screen",LoadSceneMode.Single);
        }
    }
}
