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
        Debug.Log(inside);
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
        if (inside.GetComponent<PipeScript>().curved == true)
        {
            if (transform.right == Vector3.right)
            {
                Debug.Log("sfsd");
            }
        }
        inside.tag = "Untagged";
    }
    private void OnTriggerExit(Collider other)
    {
        inside.tag = "pipe";
        cap = 90;
    }

    private void OnTriggerStay(Collider other)
    {
        if (inside.GetComponent<PipeScript>().curved == true && cap >= 1)
        {
            this.gameObject.transform.rotation *= Quaternion.Euler(0, 0, rot* 2f);
            cap-= 2f;
        }
    }
}
