﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {
	private Ball ball;
	private Vector3 dragStart,dragEnd;
	private float startTime,endTime;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball> ();
	}

	public void MoveStart(float amount){
		if (!ball.inPlay) {
			float xPos = Mathf.Clamp (ball.transform.position.x+amount, -0.5f, 0.5f);
			float yPos = ball.transform.position.y;
			float zPos = ball.transform.position.z;
			//ball.transform.Translate (new Vector3 (amount, 0, 0));
			ball.transform.position=new Vector3(xPos,yPos,zPos);
		}		
	}

	public void DragStart(){
		if (!ball.inPlay) {
			dragStart = Input.mousePosition;
			startTime = Time.time;
		}		
	}

	public void DragEnd(){
		if (!ball.inPlay) {
			dragEnd = Input.mousePosition;
			endTime = Time.time;

			float dragDuration = endTime - startTime;
			float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
			float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;
			Vector3 launchVelocity = new Vector3 (launchSpeedX / 100, 0, launchSpeedZ / 100);
			ball.Launch (launchVelocity);
		}
	}

}
