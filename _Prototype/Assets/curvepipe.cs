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
        other.GetComponent<flowing>().enabled = false;
        i = 0;
        foreach (var item in waypoints)
        {
            distance[i] = Vector3.Distance(other.transform.position, item.transform.position);
            i++;
        }

        if (Mathf.Min(distance) == distance[0])
        {
            int w = 0;
            while (w < waypoints.Length)
            {
                other.transform.position = Vector3.MoveTowards(other.transform.position, waypoints[w].position, 0.001f);
                if (Vector3.Distance(other.transform.position, waypoints[w].position) < 1)
                {
                    w++;
                }
            }
        }
        if (Mathf.Min(distance) == distance[3])
        {
            int w = waypoints.Length - 1;
            while (w >= 0)
            {
                other.transform.position = Vector3.MoveTowards(other.transform.position, waypoints[w].position, 0.001f);
                if (Vector3.Distance(other.transform.position, waypoints[w].position) < 1)
                {
                    w--;
                }
            }
        }
    }
}
