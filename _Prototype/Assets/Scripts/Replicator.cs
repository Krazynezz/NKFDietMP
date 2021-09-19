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
    [HideInInspector]
    public bool replicatable = false;

    public Transform outPutPos1;
    public Transform outPutPos2;
    public Transform outPutPos3;

    public Rigidbody plateOneFull;
    public Rigidbody plateTwoFull;
    public Rigidbody plateThreeFull;

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "PlateOne" || other.name == "PlateTwo" || other.name == "PlateThree")
        {
            platePlaced = true;
            Debug.Log("Plate placed: " + other.gameObject.name);
            if (replicatable == true)
            {
                if(other.name == "PlateOne")
                {
                    Instantiate(plateOneFull, outPutPos1.position, outPutPos1.rotation);
                }
                else if (other.name == "PlateTwo")
                {
                    Instantiate(plateTwoFull, outPutPos2.position, outPutPos2.rotation);
                }
                else if (other.name == "PlateThree")
                {
                    Instantiate(plateThreeFull, outPutPos3.position, outPutPos3.rotation);
                }
                Destroy(other.gameObject);
                replicatable = false;
                platePlaced = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        replicatable = false;
        platePlaced = false;
    }
}
