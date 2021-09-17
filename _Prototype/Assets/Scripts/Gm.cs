using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gm : MonoBehaviour
{
    GameObject current;
    public Camera camera;
    float elaspe;
     Vector3 spawn;
    public GameObject spawning;
    public GameObject spawning2;
    public GameObject spawningpipe;
    float spawned = 1;
    move refer;
    public float pipetrue;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;             //unlocks the mouse so the player can click on the pipes
        spawn = spawningpipe.transform.position;            //gets the starting location of the spheres
        foreach (var item in GameObject.FindGameObjectsWithTag("MainCamera"))           //gets the camera of the main scene
        {
            if (item.GetComponent<move>())          //gets the script of that camera
                refer = item.GetComponent<move>();      //and assigns it for future reference
        }
        refer.enabled = false;              //and sets it to false so that the player will not move in the main scene
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))           //when the player left clicks
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);     //a ray will be shot from the mouse
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))              //if the ray hit an object
                if (hit.collider.tag == "pipe")             //and it is a pipe
                {
                    current = hit.collider.gameObject;    
                    current.transform.RotateAround(hit.collider.bounds.center, Vector3.forward, 90);        //the pipe will rotate based on its collider 
                }
        }
        // if (Input.GetButtonDown("Fire2"))
        if (pipetrue == 2)              //if both end pipes are completed by recieving three spheress
        {
            SceneManager.UnloadScene("Pipes");                  //the pipe puzzle scene will be unloaded
            Cursor.lockState = CursorLockMode.Locked;           //and the mouse will be locked again 
            refer.enabled = true;                   //the movement script for the camera is back
            refer.pipes = true;                 //and one of the conditions for clearing the game is cleared
        }
        elaspe += Time.deltaTime;               //starts a timer
         if (Mathf.Ceil(elaspe) % 5 ==0 && Mathf.Ceil(elaspe) / 10 == spawned)          //after 10 seconds have passed and every subsequent 10 seconds once
         {
            if (Random.value >= 0.5f)           //a random value is used
            {
                Instantiate(spawning, spawn, Quaternion.identity);      //to determine which sphere spawn at a 50% chance
                spawned += 1;                   //and increasing the counter to wait for the next sphere to spawn
            }
            else
            {
                Instantiate(spawning2, spawn, Quaternion.identity);      //to determine which sphere spawn at a 50% chance
                spawned += 1;                   //and increasing the counter to wait for the next sphere to spawn
            }
        }
    }
}
