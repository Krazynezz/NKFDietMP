using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endpipe : MonoBehaviour
{
    float accapted;
    public Gm gm;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (accapted ==3)           //player needs to get three coorect spheres to each endpipes to clear so when this endpipe has at least three correct spheres already
        {
            gm.pipetrue++;          //the number of completed endpipes increases by one
            accapted++;             //and the number of correct spheres in this pipe increases so that it will not be called again
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Renderer>().material.color == this.gameObject.GetComponent<Renderer>().material.color)            //if the sphere and the pipes colors are the same
        {
            accapted += 1;          //number of correct spheres in this pipe increases
        }
            Destroy(other.gameObject);          //the sphere is destroyed even if it is the wrong sphere color
    }
}
