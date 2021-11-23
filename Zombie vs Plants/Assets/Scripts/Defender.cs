using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class Defender : MonoBehaviour {
	public int starCost=100;
	private StarDisplay starDisplay;

	void Start(){
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}

	public void AddStars (int amount){
		starDisplay.AddStars (amount);
	}
		

}
