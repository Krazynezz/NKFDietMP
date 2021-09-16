using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canister : MonoBehaviour
{
    static public float cancount;
    public GameObject player;
    public Vector3 end;
    // Start is called before the first frame update
    void Start()
    {
        cancount = -1;      //tracks the number of canisters on the replicator
    }

    // Update is called once per frame
    void Update()
    {
        if (cancount >= 0)          //if the is at least one canister on the replicator
            {
                this.gameObject.GetComponent<AudioSource>().clip = null;        //the audio source attached to this object will be null so that the audio will not play again
            }
    }
    private void OnTriggerEnter(Collider other)         
    {
        if (other.tag == "replicator")              //when this object collides with the replicator object
        {
            player.GetComponent<move>().interacted = false;         //the player will stop holding this object
            this.gameObject.transform.position = end;               //this object will move to the coordinates asign in inspector
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);         //and be vertically placed
            cancount += 1;          //and increase the tracker for number of canister

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "replicator")          //if the canisters are removed 
        {
            cancount--;             //the tracker will decrease
        }
    }
}
