    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plate : MonoBehaviour
{
    public Replicator replicator;
    public bool divisionright = false;
    GameObject player;
    public GameObject door;
    public static bool eaten = false;

    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("Cafeteria_Exit");       //assign the door to open
        player = Camera.main.gameObject;                //and assign the player camera when this object is spawned
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "replicator" && replicator.platePlaced == false)           //if this object collides with the replicator object and it does not have a plate inside already
        {
            player.GetComponent<move>().interacted = false;                     //the player stops holding this object
            this.gameObject.transform.position = other.transform.position;      //this plate will then move to inside the replicator
        }
            if (other.tag == "destination")         //if this plate collides with the object with the destination tag
            {
                player.GetComponent<move>().interacted = false;      //the player stops holding this object
            if (divisionright == false)                 //if this plate is the correct answer with the correct perportions as the healthy plate
            {
                this.gameObject.transform.position = this.gameObject.GetComponent<origin>().originpos;            //if it is not the right plate then it will return to its original position
                this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);                 //and original rotation
            }
            if (divisionright == true)              //if it is the right plate 
                {
                    eaten = true;               //one of the conditions to open the door will become true
                if (bottle.hydate == true)              //if the other condition for opening the door is true
                {
                    door.GetComponent<Animator>().SetBool("character_nearby", true);            //the door will open
                }
                player.GetComponent<move>().interacted = false;             //the player will stop holding this plate
                Destroy(this.gameObject);                   //and this gameobject will be destroyed

                }

        }

    }
}
