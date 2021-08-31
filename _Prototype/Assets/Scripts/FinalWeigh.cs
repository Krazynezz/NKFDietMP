using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalWeigh : MonoBehaviour
{
    float num = 0;
    public GameObject connectdoor;
    public GameObject connectdoor2;
    public GameObject[] root;
    public GameObject player;
    static bool[] weighs = new bool[] { false,false,false };
    static int weighindex = 0;
    static int complete = 0;
    public Vector3 weighplate;
    Vector3 off;
    // Start is called before the first frame update
    void Start()
    {
        off = new Vector3(0.4f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (num == 2)
        {
            weighs[weighindex] = true;
            weighindex++;
            num++;
        }
        foreach (var item in weighs)
            {
            if (item == true)
            {
                complete++;
                Debug.Log(complete);
            }
            if (item == false)
            {
                complete = 0;
            }
            }
        if (complete ==3)
        {
            Destroy(this.gameObject);
            connectdoor.GetComponent<Animator>().SetBool("character_nearby", true);
            connectdoor2.GetComponent<Animator>().SetBool("character_nearby", true);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "interactable" )
        {
            player.GetComponent<move>().interacted = false;
            other.transform.position = weighplate + off *(num-1);
            other.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        foreach (var item in root)
        {
            if (other.gameObject == item)
            {
                num++;
            }

        }
   
    }
}
