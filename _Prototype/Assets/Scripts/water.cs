using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    bool fall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > -70 && this.transform.position.y > -10)         //if the water object is vertically higher than -10 in the coordinates
        {
            fall = true;            //it should fall
        }
        if (this.transform.position.y < -70)        //if it is lower than - 70 than it should fall
        {
            fall = false;           // it should rise
        }
        if (fall == true)           //when the fall boolean is true the water will start to fall at a rate of 0.01 every update frame
        {
            this.transform.position -= Vector3.up / 100;
        }
        if (fall == false)
        {
            this.transform.position += Vector3.up / 100;        //and will also rise at the same rate
        }
    }
}
