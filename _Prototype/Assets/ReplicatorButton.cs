using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplicatorButton : MonoBehaviour
{
    public Replicator replicator;
    

    private void OnMouseDown()
    {
        Debug.Log(canister.cancount);
        //Debug.Log("Button Clicked");
        if (canister.cancount >= 2 && replicator.platePlaced == true)
        {
            replicator.replicatable = true;
            Debug.Log("Replicating!");
        }
        else
        {
            Debug.Log("Something is missing");
        }
        //Debug.Log(replicator.platePlaced);
    }

    /*
    private void OnMouseUp()
    {
        replicator.replicatable = false;
    }*/
}
