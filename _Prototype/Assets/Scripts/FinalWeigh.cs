using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalWeigh : MonoBehaviour
{
    float num = 0;
    public GameObject connectdoor;
    public GameObject connectdoor2;
    public GameObject connectdoor3;
    public Material root;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (num == 2)
        {
            Destroy(this.gameObject);
            connectdoor.GetComponent<Animator>().SetBool("character_nearby", true);
            connectdoor2.GetComponent<Animator>().SetBool("character_nearby", true);
            connectdoor3.GetComponent<Animator>().SetBool("character_nearby", true);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "interactable" )
        {
            num += 1;
        }
    }
}
