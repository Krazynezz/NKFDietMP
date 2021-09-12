using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject player;
    public bool lastintro;
    public GameObject nextintro;
    float delay;
    Outline outline;
    static bool outlined;
    // Start is called before the first frame update
    void Awake  ()
    {
        if (outlined == false)
        {
            foreach (var item in GameObject.FindGameObjectsWithTag("interactable"))
            {
                item.AddComponent<origin>();
                outline = item.AddComponent<Outline>();
                outline.OutlineMode = Outline.Mode.OutlineVisible;
                outline.OutlineWidth = 10f;
            }
            outlined = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        delay += Time.deltaTime;
        if (delay > 1)
        {
            if (Input.anyKey)
            {
                this.gameObject.active = false;

                if (lastintro == true)
                {
                    player.GetComponent<move>().enabled = true;
                    crosshair.active = true;
                }
                else
                {
                    nextintro.active = true;
                }
            }
        }   
    }
}
