using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Placement : MonoBehaviour
{
    public GameObject Waterbottle;
    public GameObject player;
    public GameObject container;
    bool done = false;
    static float cheat;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {}
    private void OnTriggerEnter(Collider item)
    {
        
    
               if (item.tag == "interactable" && done != true)
                {
                    player.GetComponent<move>().interacted = false;
                    item.transform.position = transform.position + Vector3.up/5;
                    item.transform.rotation = Quaternion.Euler(0, 90, 0);
                    done = true;
                    cheat += 1;
                }
            
        
        if (cheat == 5)
        {
            Instantiate(Waterbottle,container.transform.position,Quaternion.identity);
            cheat += 1;
        }
    }
}
