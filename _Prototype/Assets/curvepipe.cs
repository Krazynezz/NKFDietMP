using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curvepipe : MonoBehaviour
{
    Transform[] waypoints = new Transform[4] ;

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach (Transform child in transform)
        {
            Debug.Log(child);
            waypoints[i] = child;
            i++;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
