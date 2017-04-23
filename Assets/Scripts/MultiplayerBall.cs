using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        // Check if the object the ball collided with had a PlayerHealth component
        PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();
        if (health != null)
        {
            // Since it did, take damage on the component
            health.TakeDamage(1);
        }
        // Destroy the ball
        Destroy(gameObject);
    }
}
