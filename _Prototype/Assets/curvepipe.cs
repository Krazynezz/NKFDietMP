using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curvepipe : MonoBehaviour
{
    Transform[] waypoints;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            waypoints[waypoints.Length] = child;
            Debug.Log(child);
            Debug.Log(waypoints.Length);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
