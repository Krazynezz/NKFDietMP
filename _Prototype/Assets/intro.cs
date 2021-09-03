using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<move>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            player.GetComponent<move>().enabled = true;
            crosshair.active = true;
            this.gameObject.active = false;

        }
    }
}
