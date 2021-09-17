using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class intro : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject player;
    public bool lastintro;
    public GameObject nextintro;
    float delay;
    Outline outline;
    static bool outlined;
    public Insertion insertion;
        //using scriptable object to try and reduce memory
/*    void Awake()
    {
            if (outlined == false)              //if the outline is not attached yet
        {    
            insertion.interactables = GameObject.FindGameObjectsWithTag("interactable");        //gets all interactable objects in the scene
            EditorUtility.SetDirty(insertion);              //and saves it
                foreach (GameObject item in insertion.interactables)            //and for every interactable object
            {
                item.AddComponent<origin>();        //add the origin script to allow the player to interact with the objects
                outline = item.AddComponent<Outline>();             //and the outline script to add a outline to the object
                outline.OutlineMode = Outline.Mode.OutlineVisible;              //sets the outline mode
                outline.OutlineWidth = 10f;             //and outline thickness
            }   
            outlined = true;                //and disables this code afterwards
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        delay += Time.deltaTime;            //a timer is started
        if (delay > 1)              //after the timer has passed 1 second
        {
            if (Input.anyKey)           //the player can press any key
            {
                this.gameObject.SetActive(false);           //to disable this screen of introduction

                if (lastintro == true)          //and if it is the last introduction screen
                {
                    player.GetComponent<move>().enabled = true;     //then the player is allowed to move
                    crosshair.SetActive(true);              //and see the crosshair
                }
                else          //if it is not the last introduction screen
                {
                    nextintro.SetActive(true);      //then the next introduction screen plays
                }
            }
        }   
    }
}
