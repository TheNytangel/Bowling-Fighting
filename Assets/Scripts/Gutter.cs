using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gutter : MonoBehaviour {
    private LaneManager thisLaneManager;

	// Use this for initialization
	void Start ()
    {
        // Get the lane manager for the lane that the gutter is in
        thisLaneManager = transform.parent.transform.parent.gameObject.GetComponent<LaneManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    // Using OnTriggerStay in case there are multiple gutter balls. If there are mutiple gutter balls
    // and one destroys itself, it would call OnTriggerExit and it would show that there are no gutter
    // balls even though there could still be balls in the gutter
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            // Gutter ball
            thisLaneManager.hasGutterBall(true);
        }
    }
}
