using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {
	public Ball ball;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - ball.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (ball.transform.position.z <= 18.29f) {
			transform.position = ball.transform.position+offset;
		}

	}
}
