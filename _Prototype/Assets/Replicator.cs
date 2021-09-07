using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Replicator : MonoBehaviour
{
    [HideInInspector]
    public Placement placement;

    private void OnMouseDown()
    {
        Debug.Log("Button Clicked");
    }
}
