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
        hit = Physics.OverlapBox(this.gameObject.transform.position+Vector3.forward/10,Vector3.one/50);
        if (hit != null)
        {
            foreach (var item in hit)
            {
                if (item.name == card.name)
                {
                    animator.GetComponent<Animator>().SetBool("character_nearby", true);
                }
            }
        }
    }
}
