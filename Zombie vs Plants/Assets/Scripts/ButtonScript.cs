using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {
	public GameObject defenderPrefab;
	public static GameObject selectedDefender;
	private ButtonScript[] buttonArray;
	private Text costText;

	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<ButtonScript>();
		costText = GetComponentInChildren<Text>();
		if (!costText) {
			Debug.LogWarning (name +" has no cost text");
		}
		costText.text = defenderPrefab.GetComponent<Defender> ().starCost.ToString ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown () {
		foreach (ButtonScript thisButton in buttonArray){
			thisButton.GetComponent<SpriteRenderer> ().color = Color.black;
		}
		GetComponent<SpriteRenderer> ().color = Color.white;
		selectedDefender = defenderPrefab;

	}

}
