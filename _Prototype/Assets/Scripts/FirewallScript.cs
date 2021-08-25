using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirewallScript : MonoBehaviour
{
    float num = -1;
    public GameObject player;
    Vector3 off;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (num == 3)
        {
            this.gameObject.transform.parent.gameObject.transform.position -= Vector3.up/10 ;
            Destroy(GameObject.Find("Cereal"));
            Destroy(GameObject.Find("RaspberryBuzz"));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "interactable" && (other.name == "Cereal")|| other.name == "RaspberryBuzz")
        {
            off = new Vector3(0, 1, num) /3;
            player.GetComponent<move>().interacted = false;
            other.gameObject.transform.position = this.gameObject.transform.position + off;
            other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            num += 2;

        }
    }
}
