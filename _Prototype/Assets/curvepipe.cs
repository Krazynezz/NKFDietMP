using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curvepipe : MonoBehaviour
{
    Transform[] waypoints;
    Transform[] children;   
    // Start is called before the first frame update
    void Start()
    {
        children = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            Debug.Log(child);
            waypoints[waypoints.Length] = child;
            Debug.Log(waypoints.Length);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
