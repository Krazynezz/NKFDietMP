using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    float[] rotations = { 0,90,180,270 };
    public bool curved;

    private void Start()
    {
        int rand = Random.Range(0, rotations.Length);
        transform.RotateAround(this.gameObject.GetComponent<Collider>().bounds.center, Vector3.forward, rotations[rand]);

    }
}
