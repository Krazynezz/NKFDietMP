using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Replicator : MonoBehaviour
{
    [HideInInspector]
    public canister canister;
    bool platePlaced = false;

    private void OnMouseDown()
    {
        Debug.Log("Button Clicked");
        if (canister.cancount == 3 && platePlaced == true)
        {
            Debug.Log("3 canisters placed");
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlateOne" || other.name == "PlateTwo" || other.name == "PlateThree")
        {
            Debug.Log("Hello");
        }
    }
}
