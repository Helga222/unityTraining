using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {
	public enum Status{SUCCESS,FAILURE};
	private Text starText;
	private int stars=100;

	// Use this for initialization
	void Start () {
		starText = gameObject.GetComponent<Text>();
		UpdateStars ();
		
	}

	public void AddStars(int amount){
		stars += amount;
		UpdateStars ();
	}

	public Status UseStars(int amount){
		if (stars >= amount) {
			stars -= amount;
			UpdateStars ();
			return Status.SUCCESS;
		} 
		return Status.FAILURE;
	}

	private void UpdateStars(){
		starText.text = stars.ToString ();
	}
}
