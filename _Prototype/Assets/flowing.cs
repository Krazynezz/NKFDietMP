using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowing : MonoBehaviour
{
    GameObject inside;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(inside);
        this.gameObject.transform.position -= transform.right/5000;
        Collider[] hitColliders = Physics.OverlapBox(this.gameObject.transform.position,Vector3.one/10);
        foreach (var item in hitColliders)
        {
            if (item.tag == "pipe")
            {
                inside = item.gameObject;
            }
            if (item.GetComponent<PipeScript>().curved == true)
            {
                if (this.gameObject.transform.position == item.transform.position)
                this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        inside.tag = "Untagged";
    }
    private void OnTriggerExit(Collider other)
    {
        inside.tag = "pipe";
    }

}
