    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plate : MonoBehaviour
{
    Vector3 origin;
    public bool divisionright = false;
    public GameObject player;
    public static GameObject door;
    public static bool eaten = false;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "replicator")
        {
            player.GetComponent<move>().interacted = false;
            this.gameObject.transform.position = other.transform.position;
        }
            if (other.tag == "destination")
            {
                player.GetComponent<move>().interacted = false;
            if (divisionright == false)
            {
                this.gameObject.transform.position = origin;
                this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (divisionright == true)
            {
                eaten = true;    
                if (bottle.hydate == true)
                {
                    door.GetComponent<Animator>().SetBool("character_nearby", true);
                }    
                Destroy(this.gameObject);

            }

        }

    }
}
