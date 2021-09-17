using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement2 : MonoBehaviour
{
    public GameObject Item;
    public GameObject player;
    public GameObject connectdoor;
    static public float correctItems;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (correctItems == 3)          //all three figurines have placed correctly
        {
            connectdoor.GetComponent<Animator>().SetBool("character_nearby",true);              //then door attached should open
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "interactable")        //if an interactable object collides with this object
        {
            player.GetComponent<move>().interacted = false;         //the player will stop holding the object
            other.transform.position = this.gameObject.transform.position + Vector3.up/ 100;        //and be placed above this platform
            other.transform.rotation = Quaternion.Euler(0, 0, 0);           //at the original rotation
            if (other.gameObject == Item)           //if the item is the same as the intended object assigned in inspector
            {
                correctItems += 1;              //the number of correct objects will increase
            }
        }
    }
}
