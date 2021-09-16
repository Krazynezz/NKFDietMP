using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottle : MonoBehaviour
{
    public GameObject player;
    public GameObject door;
    public static bool hydate = false;

    // Start is called before the first frame update
    void Start()
    {
        player = Camera.main.gameObject;            //assigns player object to manipulate interact funtion code
        door = GameObject.Find("Cafeteria_Exit");           //assigns door to be opened if conditions are met
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "destination")         //if this object colides with the object with the object with the destination tag
        {
            player.GetComponent<move>().interacted = false;         //the player will stop holding this object
            hydate = true;          //one of the conditions for opening the door will become true
            if (plate.eaten == true)            //if the other condition is true already
            {
                door.GetComponent<Animator>().SetBool("character_nearby", true);        //then the door will open
            }
            Destroy(this.gameObject);           //and then this objecct is destroyed
        }

    }
}
