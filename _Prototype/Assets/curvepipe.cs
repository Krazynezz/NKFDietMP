using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curvepipe : MonoBehaviour
{
    Transform[] waypoints = new Transform[4];
    float[] distance = new float[4];
    int i = 0;
    int head = 0;
    int tail = 3;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
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
        other.GetComponent<flowing>().enabled = false;
        i = 0;
        foreach (var item in waypoints)
        {
            distance[i] = Vector3.Distance(other.transform.position, item.transform.position);
            i++;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (Mathf.Min(distance) == distance[0])
        {
            {
                other.transform.position = Vector3.MoveTowards(other.transform.position, waypoints[head].position, 0.001f);
                if (Vector3.Distance(other.transform.position, waypoints[head].position) < 0.001)
                {
                    head++;
                }
            }
        }
        if (Mathf.Min(distance) == distance[3])
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, waypoints[tail].position, 0.001f);
            if (Vector3.Distance(other.transform.position, waypoints[tail].position) < 0.001)
            {
                tail--;
            }         
        }
        }
    }
