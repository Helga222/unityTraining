using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {
	private LevelManager levelManger;

	// Use this for initialization
	void Start () {
		levelManger = GameObject.FindObjectOfType<LevelManager> ();
		
	}
	
	void OnTriggerEnter2D(){
		levelManger.LoadLevel ("03b Lose");
		
	}
}
