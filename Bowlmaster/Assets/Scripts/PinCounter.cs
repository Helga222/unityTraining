using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PinCounter : MonoBehaviour {
	public Text text;
	private bool ballOutOfPlay = false;
	private int lastStandingCount=-1;
	private float lastChangeTime;
	private int lastSettledCount = 10;
	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager> ();

	}

	// Update is called once per frame
	void Update () {
		text.text = CountStanding ().ToString ();
		if (ballOutOfPlay) {
			UpdateStandingCountAndSettle ();
			text.color = Color.red;
		}		
	}

	void UpdateStandingCountAndSettle (){
		if (lastStandingCount!= CountStanding ()) {
			lastStandingCount = CountStanding ();
			lastChangeTime = Time.deltaTime;
			return;
		}
		float settleTime = 0.03f;
		if (Time.deltaTime-lastChangeTime>settleTime) {
			PinsHaveSettled ();
		}
		print (Mathf.Abs(Time.deltaTime-lastChangeTime));
		//print ("lastChangeTime= "+lastChangeTime);
	}

	void PinsHaveSettled(){
		int standing = CountStanding ();
		int pinFall = lastSettledCount - standing;
		lastSettledCount = standing;
		gameManager.Bowl (pinFall);

		lastStandingCount = -1;
		ballOutOfPlay = false;
		text.color = Color.green;		
	}

	int CountStanding (){
		int standing = 0;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding ()) {
				standing = standing+1;
			}						
		}
		return standing;
	}

	public void Reset (){
		lastSettledCount = 10;
	}


	// Update is called once per frame
	void OnTriggerExit (Collider collider) {
		if (collider.gameObject.name == "Ball") {
			ballOutOfPlay = true;
		}

	}
}
