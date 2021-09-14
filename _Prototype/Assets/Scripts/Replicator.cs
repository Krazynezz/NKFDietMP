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

    public Transform outPutPos;

    public Rigidbody plateOneFull;
    public Rigidbody plateTwoFull;
    public Rigidbody plateThreeFull;

    //string placedPlate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlateOne" || other.name == "PlateTwo" || other.name == "PlateThree")
        {
            platePlaced = true;
            Debug.Log("Plate placed: " + other.gameObject.name);
            //other.gameObject.name = placedPlate;
        }
    }

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
                    Instantiate(plateOneFull, outPutPos.position, outPutPos.rotation);
                }
                else if (other.name == "PlateTwo")
                {
                    Instantiate(plateTwoFull, outPutPos.position, outPutPos.rotation);
                }
                else if (other.name == "PlateThree")
                {
                    Instantiate(plateThreeFull, outPutPos.position, outPutPos.rotation);
                }
                Destroy(other.gameObject);
                replicatable = false;
                platePlaced = false;
            }
        }

        /*
        if (other.gameObject.name == placedPlate && replicatable == true)
        {
            if (other.name == "PlateOne")
            {
                Instantiate(plateOneFull, outPutPos.position, outPutPos.rotation);
            }
            else if (other.name == "PlateTwo")
            {
                Instantiate(plateTwoFull, outPutPos.position, outPutPos.rotation);
            }
            else if (other.name == "PlateThree")
            {
                Instantiate(plateThreeFull, outPutPos.position, outPutPos.rotation);
            }
            Destroy(other.gameObject);
            replicatable = false;
            platePlaced = false;
        }
        */
    }

    private void OnTriggerExit(Collider other)
    {
        replicatable = false;
        platePlaced = false;
    }
}
