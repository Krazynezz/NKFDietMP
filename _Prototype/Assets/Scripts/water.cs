using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    bool rise;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > -70 && this.transform.position.y > -10)
        {
            rise = true;
        }
        if (this.transform.position.y < -70)
        {
            rise = false;
        }
        if (rise == true)
        {
            this.transform.position -= Vector3.up / 100;
        }
        if (rise == false)
        {
            this.transform.position += Vector3.up / 100;
        }
    }
}
