using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour

{
    public GameObject card;
    RaycastHit cardcheck;
    public Animator animator;
    bool hit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
        {
            
        hit = Physics.BoxCast(this.gameObject.transform.position,Vector3.one*10,Vector3.zero, out cardcheck);
        if (hit)
            { 
            Debug.Log(cardcheck.collider.name);
            if (cardcheck.collider.gameObject.name == card.name)
            {
                animator.SetBool("character_nearby", true);
            }
        }
    }
}
