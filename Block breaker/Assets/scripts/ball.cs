﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {
    private paddle paddle;
    private Vector3 paddleToBallVector;
    private bool hasStarted=false;


	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        print(hasStarted);
    }
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted) { 
        this.transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                print("Mouse clicked, launch ball");
                hasStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }

        }


    }
    private void OnCollisionEnter2D(Collision2D collision)   {
        Vector2 tweak = new Vector2(Random.Range(0f,0.2f), Random.Range(0f, 0.2f));
        print(tweak);
        if (hasStarted){
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }



    }

}
