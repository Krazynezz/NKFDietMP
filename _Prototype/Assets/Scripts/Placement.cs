using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Placement : MonoBehaviour
{
    public GameObject Waterbottle;
    public GameObject player;
    public GameObject container;
    private bool done = false;
    static float canned;
    public string correct;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canned == 5)                //if all cans have been placed correctly 
        {
            Instantiate(Waterbottle, container.transform.position, Quaternion.identity);        //then the water that is part of a healthy meal will spawn
            canned += 10;            //and the tracker for the cans will increase so that it will not spawn another water
        }
    }
    private void OnTriggerEnter(Collider item)
    {        
        if (item.tag == "interactable" && done != true)                    //when this object collides with an interactable object and this position does not have a can already
        {
                    player.GetComponent<move>().interacted = false;         //the player will stop holding the object
                    item.transform.position = transform.position + Vector3.up/5;            //and the object will move to above this position 
                    item.transform.rotation = Quaternion.Euler(0, -90, 0);          //and face the edge of the table
                    done = true;                    //and this position will have a can already in case another can is trying to be placed here
            if (item.name == correct)           //if the name of the object placed in this position is the same as the intended name
            {
                canned += 1;                //then it will increase the number of correct cans that have been placed by one
            } 
        }
            

    }
    private void OnTriggerExit(Collider item)
    {
        done = false;
        if (item.name == correct)
        {
            canned -= 1;
        }
    }
}
