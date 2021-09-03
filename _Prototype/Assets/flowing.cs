using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowing : MonoBehaviour
{
    GameObject inside;
    float cap = 90;
    float rot= 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position -= transform.right/5000;
        Collider[] hitColliders = Physics.OverlapBox(this.gameObject.transform.position,Vector3.one/10);
        foreach (var item in hitColliders)
        {
            if (item.tag == "pipe")
            {
                inside = item.gameObject;
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
        cap = 90;
    }

    private void OnTriggerStay(Collider other)
    { 
    }
}
