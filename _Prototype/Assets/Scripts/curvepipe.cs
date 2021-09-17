using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curvepipe : MonoBehaviour
{    
    float[] rotations = { 0, 90, 180, 270 };
    Transform[] waypoints = new Transform[6];
    float[] distance = new float[6];
    int i = 0;
    int head = 1;
    int tail = 4;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, rotations.Length);       //a random 90 degrees is set
        transform.RotateAround(this.gameObject.GetComponent<Collider>().bounds.center, Vector3.forward, rotations[rand]);                      //all pipes will be rotated to the random 90 degrees when spawned
        foreach (Transform child in transform)
        {
            waypoints[i] = child;               //each pipe has a list of empty game objects that is gotten and assigned to be referenced later
            i++;

        }
    }


// Update is called once per frame
void Update()
    {

    }
    private void OnTriggerEnter(Collider other)         //when a sphere collides and enters the pipe
    {
        other.GetComponent<flowing>().enabled = false;          //it will stop moving by itself
        i = 0;
        foreach (var item in waypoints)     //and the list of empty gameobject in the children is used
        {
            distance[i] = Vector3.Distance(other.transform.position, item.transform.position);          //to find the difference between sphere position and each empty game object
            i++;            //and is saved in a seperate array
        }
    }
    private void OnTriggerStay(Collider other)          //while the sphere is in the pipe
    {
        this.tag = "Untagged";              //this pipe cannot be rotated since the rotation requires the tag
        if (Mathf.Min(distance) == distance[1])         //and the smallest difference between sphere position and each empty game object is used to determine which end of the pipe the sphere is at
        {
            {
                other.transform.position = Vector3.MoveTowards(other.transform.position, waypoints[head].position, 0.001f);         //and the sphere will move towards the closest waypoint
                if (Vector3.Distance(other.transform.position, waypoints[head].position) < 0.001)           //until it is close enough to that waypoint
                {
                    head++;             //then it start to move to the next waypoint
                }
            }
        }
        if (Mathf.Min(distance) == distance[4])             //if the sphere is at the other end of the pipe
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, waypoints[tail].position, 0.001f);         //then it will move in the othe direction
            if (Vector3.Distance(other.transform.position, waypoints[tail].position) < 0.001)
            {
                tail--;
            }         
        }
        if(Mathf.Min(distance) == distance[2]|| Mathf.Min(distance) == distance[3])         //if the sphere is not close to the two ends of the pipe
        {
            Destroy(other.gameObject);          //it is not entering the pipe at the right ends so it is destroyed
        }
        }
    private void OnTriggerExit(Collider other)              //when the sphere leaves the pipe
    {
        tail = 4;
        head = 1;               //the variables are reset
        this.tag = "pipe";      //and the pipe can be rotated again
    }
}
