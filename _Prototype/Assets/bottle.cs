using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottle : MonoBehaviour
{
    public GameObject player;
    public static bool hydate = false;

    // Start is called before the first frame update
    void Start()
    {
        player = Camera.main.gameObject;
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
                //plate.GetComponent<Animator>().SetBool("character_nearby", true);
            }
        }

    }
}
