using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position -= transform.right / 3000;       //the spheres will move to towards the pipes when they spawn
    }
}
