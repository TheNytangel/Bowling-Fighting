using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetRidOfPlayerBody : NetworkBehaviour {

    public GameObject getRidOf;

    // Use this for initialization
    public override void OnStartLocalPlayer()
    {
        // Hide the gameobject so the player doesn't see it
        getRidOf.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
