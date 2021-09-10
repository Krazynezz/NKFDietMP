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
        player = Camera.main.gameObject;
        door = GameObject.Find("Cafeteria_Exit");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "destination")
        {
            player.GetComponent<move>().interacted = false;
            Destroy(this.gameObject);
            hydate = true;
            if (plate.eaten == true)
            {
                door.GetComponent<Animator>().SetBool("character_nearby", true);
            }
        }

    }
}
