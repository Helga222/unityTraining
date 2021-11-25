using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
	public GameObject pinSet;

	//private ActionMaster actionMaster = new ActionMaster ();
	private Animator animator;
	private PinCounter pinCounter;
	// Use this for initialization
	void Start () {
		//ball = GameObject.FindObjectOfType<Ball> ();
		animator = GetComponent<Animator> ();
		pinCounter = GameObject.FindObjectOfType<PinCounter> ();

	}

	// Update is called once per frame
	void Update () {

	}

	public void RaisePins() {
			foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.RaiseIfStanding ();
		}
	}

	public void LowerPins() {
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.Lower ();			
		}
	}

	public void RenewPins() {
		Instantiate (pinSet,new Vector3(0,0.3f,18.29f),Quaternion.identity);
	}

	public void PerformAction (ActionMasterOld.Action action) {
		if (action == ActionMasterOld.Action.Tidy) {
			animator.SetTrigger ("tidyTrigger");
		} else if (action == ActionMasterOld.Action.Reset) {
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset ();
		} else if (action == ActionMasterOld.Action.EndTurn) {
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset ();
		} else if (action == ActionMasterOld.Action.EndTurn) {
			throw new UnityException ("Dont knowhow to finish game yet");
		}
	}

	  
}
