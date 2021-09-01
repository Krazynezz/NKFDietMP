using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curvepipe : MonoBehaviour
{
    Transform[] waypoints = new Transform[4];
    float[] distance = new float[4];
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
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
    private void OnTriggerEnter(Collider other)
    {
        i = 0;
        foreach (var item in waypoints)
        {
            distance[i] = Vector3.Distance(other.transform.position, item.transform.position);
            i++;
        }
        if (Mathf.Min(distance) == distance[0])
        {
            i = 0;
            other.transform.position = Vector3.MoveTowards(other.transform.position, waypoints[i].position, 0.001f);
            if (Vector3.Distance(other.transform.position, waypoints[i].position)<1 && i<3)
            {
                i++;
            }
        }
        if (Mathf.Min(distance) == distance[3])
        {
            i = 3;
            other.transform.position = Vector3.MoveTowards(other.transform.position, waypoints[i].position, 0.001f);
            if (Vector3.Distance(other.transform.position, waypoints[i].position) < 1 && i >0)
            {
                i--;
            }
        }
    }
}
