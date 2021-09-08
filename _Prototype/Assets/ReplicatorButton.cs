using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplicatorButton : MonoBehaviour
{
    public Replicator replicator;

    private void OnMouseDown()
    {
        /*
        Debug.Log(canister.cancount);
        Debug.Log("Button Clicked");
        if (canister.cancount == 2 && replicator.platePlaced == true)
        {
            Debug.Log("3 canisters placed");
        }
        else
        {
            Debug.Log("Something is missing");
        }
        */
        Debug.Log(replicator.platePlaced);

    }
}
