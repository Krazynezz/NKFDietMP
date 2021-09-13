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
        if (accapted ==3)
        {
            gm.pipetrue++;
            accapted++;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Renderer>().material.color == this.gameObject.GetComponent<Renderer>().material.color)
        {
            accapted += 1;
            Destroy(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
