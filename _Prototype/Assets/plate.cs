    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plate : MonoBehaviour
{
    Vector3 origin;
    public bool divisionright = false;
    public GameObject player;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.tag == "destination")
        {
            player.GetComponent<move>().interacted = false;
            if (divisionright == false)
            {
                this.gameObject.transform.position = origin;
                this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (divisionright == true)
            {
                Destroy(this.gameObject);
                door.GetComponent<Animator>().SetBool("character_nearby", true);

            }

        }

    }
}
