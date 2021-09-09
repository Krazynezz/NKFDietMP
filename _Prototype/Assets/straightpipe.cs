using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class straightpipe : MonoBehaviour
{
    float[] rotations = { 0, 90, 180, 270 };
    Transform[] waypoints = new Transform[4];
    float[] distance = new float[4];
    int i = 0;
    int head = 1;
    int tail = 2;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, rotations.Length);
        transform.RotateAround(this.gameObject.GetComponent<Collider>().bounds.center, Vector3.forward, rotations[rand]);
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
            Debug.Log("afre");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (Mathf.Min(distance) == distance[1])
        {
            {
                other.transform.position = Vector3.MoveTowards(other.transform.position, waypoints[head].position, 0.001f);
                if (Vector3.Distance(other.transform.position, waypoints[head].position) < 0.001)
                {
                    head++;
                }
                if (head >= 6)
                {

                }
            }
        }
        if (Mathf.Min(distance) == distance[2])
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, waypoints[tail].position, 0.001f);
            if (Vector3.Distance(other.transform.position, waypoints[tail].position) < 0.001)
            {
                tail--;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        tail = 2;
        head = 1;

    }
}
