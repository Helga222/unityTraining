using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public bool inPlay=false;
	public Vector3 launchVelocity;

	private Rigidbody rigidBody;
	private AudioSource audioSource;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody.useGravity = false;
		audioSource = GetComponent<AudioSource> ();
	}

	public void Launch (Vector3 velocity)
	{		
		inPlay = true;
		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;

		audioSource.Play();
	}

	public void Reset(){
		inPlay = false;
		transform.position = startPosition;
		transform.rotation = Quaternion.identity;
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.velocity = Vector3.zero;
		rigidBody.useGravity = false;
	}

}
