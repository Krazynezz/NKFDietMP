using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class straightpipe : MonoBehaviour
{
    float[] rotations = { 0, 90, 180, 270 };
    Transform[] waypoints = new Transform[4];
    float[] distance = new float[4];
    int i = 0;
    int path = 1;
    // Start is called before the first frame update
    void Start()
    {

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
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, waypoints[path].position, 0.001f);
            if (Vector3.Distance(other.transform.position, waypoints[path].position) < 0.001)
            {
                path++;
            }
        }
    }
}
