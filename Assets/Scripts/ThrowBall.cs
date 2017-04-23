using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ThrowBall : NetworkBehaviour {

    public GameObject bowlingBall;
    
    private Transform tf;
    private Transform camTf;

	// Use this for initialization
	void Start ()
    {
        // Get transform components for the character and for the camera of the character
        tf = GetComponent<Transform>();
        camTf = tf.Find("FirstPersonCharacter").GetComponent<Camera>().GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!isLocalPlayer)
            return;

        // Left mouse button to shoot at other players
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            CmdFire();
        }

        // Right mouse button to shoot at pins
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            ShootBallSinglePlayer();
        }
	}

    [Command]
    void CmdFire()
    {
        // Calculate the location to shoot the ball out of
        Vector3 locationToSpawn = tf.position + new Vector3(0, 0.25F, 0) + tf.forward;

        // Make the ball
        GameObject spawnedBall = Instantiate(bowlingBall, locationToSpawn, Quaternion.identity) as GameObject;

        // Add the "multiplayer ball" component to the ball. This checks if it collides with another player
        spawnedBall.AddComponent<MultiplayerBall>();

        // Get the rigidbody component and add velocity to the ball
        Rigidbody ballRigidBody = spawnedBall.GetComponent<Rigidbody>();
        ballRigidBody.velocity = tf.forward * 50;

        // Spawn the ball on the server
        NetworkServer.Spawn(spawnedBall);

        // Despawn after 10 seconds
        Destroy(spawnedBall, 10.0F);
    }

    void ShootBallSinglePlayer()
    {
        // Shoot the ball relative to the camera
        Vector3 locationToSpawn = camTf.position - new Vector3(0, 0.5F, 0) + camTf.forward;
        // Add 4000 forces in the forward direction
        Vector3 forceToAdd = camTf.forward * 4000.0F;

        // Spawn the ball
        GameObject spawnedBall = Instantiate(bowlingBall, locationToSpawn, Quaternion.identity) as GameObject;

        // Get rigidbody, set "use gravity" to true so it falls, and add force
        Rigidbody ballRigidBody = spawnedBall.GetComponent<Rigidbody>();
        ballRigidBody.useGravity = true;
        ballRigidBody.AddForce(forceToAdd);

        // Despawn after 10 seconds
        Destroy(spawnedBall, 10.0F);
    }
}
