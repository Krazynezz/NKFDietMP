using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class origin : MonoBehaviour
{
    public Vector3 originpos;
    // Start is called before the first frame update
    void Start()
    {
        originpos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
