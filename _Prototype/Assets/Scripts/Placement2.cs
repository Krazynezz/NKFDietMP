using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement2 : MonoBehaviour
{
    public Vector3 lockpos;
    public GameObject Item;
    public GameObject player;
    public GameObject connectdoor;
    RaycastHit hit;
    //public bool done = false;
    static public float correctItems;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (correctItems == 3)
        {
            connectdoor.GetComponent<Animator>().SetBool("character_nearby",true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "interactable")
        {
            player.GetComponent<move>().interacted = false;
            other.transform.position = this.gameObject.transform.position + Vector3.up/ 100;
            other.transform.rotation = Quaternion.Euler(0, 0, 0);
            if (other.gameObject == Item)
            {
                correctItems += 1;
            }
        }
    }
}
