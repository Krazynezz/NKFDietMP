using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour

{
    public GameObject card;
    public GameObject animator;
    Collider[] hit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
        {
        hit = Physics.OverlapBox(this.gameObject.transform.position+Vector3.forward/10,Vector3.one/50);             //scan the area of a box in front of the scanner 
        if (hit != null)            //if the scan detects something
        {
            foreach (var item in hit)
            {
                if (item.name == card.name)             //and if it has the same name as the variable stored in inspector
                {
                    animator.GetComponent<Animator>().SetBool("character_nearby", true);        //than the door attached to this script should open
                }
            }
        }
    }
}
