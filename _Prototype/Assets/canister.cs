using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canister : MonoBehaviour
{
    static public float cancount;
    public GameObject player;
    public Vector3 end;
    Vector3 off;
    // Start is called before the first frame update
    void Start()
    {
        cancount = -1;
        off = Vector3.left/5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "replicator")
        {
            player.GetComponent<move>().interacted = false;
            this.gameObject.transform.position = end + off * cancount;
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            cancount += 1;
        }
    }
}
