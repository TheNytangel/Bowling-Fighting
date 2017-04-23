using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StartPosition : MonoBehaviour {

    private Transform tf;
    private Rigidbody rig;
    private Vector3 startPosition;
    private Quaternion startRotation;

	// Use this for initialization
	void Start () {
        // Get the transform, rigidbody, and then start position and rotation of the pins
        tf = GetComponent<Transform>();
        rig = GetComponent<Rigidbody>();
        startPosition = tf.position;
        startRotation = new Quaternion(0, 0, 0, 0);
        
        // Make sure all the pins are set up
        resetPosition();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void resetPosition()
    {
        // Reset the pins to their start position and rotation
        tf.position = startPosition;
        tf.rotation = startRotation;
        // Reset the velocity and angular velocity of the pins to 0 in case they were falling when they got reset
        rig.velocity = Vector3.zero;
        rig.angularVelocity = Vector3.zero;
    }
}
