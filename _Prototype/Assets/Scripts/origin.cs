using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class origin : MonoBehaviour
{
    public Vector3 originpos;           //should be attached to any interactable object
    // Start is called before the first frame update
    void Start()
    {
        originpos = this.gameObject.transform.position;         //sets the origin location of each object this script is attached to 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
