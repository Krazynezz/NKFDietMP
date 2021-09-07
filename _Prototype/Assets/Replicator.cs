using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Replicator : MonoBehaviour
{
    [HideInInspector]
    public canister canister;
    [HideInInspector]
    public bool platePlaced = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "PlateOne" || other.name == "PlateTwo" || other.name == "PlateThree")
        {
            platePlaced = true;
            Debug.Log("Plate placed: "+ other.gameObject.name);  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        platePlaced = false;
    }
}
