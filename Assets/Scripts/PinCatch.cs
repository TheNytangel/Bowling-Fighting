using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCatch : MonoBehaviour {

    private LaneManager thisLaneManager;

	// Use this for initialization
	void Start () {
        // Get the lane manager for the lane that the pin catch is in
        thisLaneManager = transform.parent.gameObject.GetComponent<LaneManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        // If a pin fell in, add a pin to the count of pins in the manager
        if(other.CompareTag("Pin"))
        {
            thisLaneManager.addPin();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If a pin fell out, subtract a pin from the count of pins in the manager
        if (other.CompareTag("Pin"))
        {
            thisLaneManager.removePin();
        }
    }
}
