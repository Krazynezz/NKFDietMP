using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplicatorButton : MonoBehaviour
{
    public Replicator replicator;
    
    private void OnMouseDown()
    {
        Debug.Log(canister.cancount);
        if (canister.cancount >= 2 && replicator.platePlaced == true)
        {
            replicator.replicatable = true;
            Debug.Log("Replicating!");
        }
        else
        {
            Debug.Log("Something is missing");
        }
    }
}
