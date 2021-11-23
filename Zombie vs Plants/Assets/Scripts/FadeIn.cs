using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {
	public float fadeInTime;
	private Image fadePanel;
	private Color currentColor=Color.black;

	// Use this for initialization
	void Start () {
		fadePanel = GameObject.Find("Fade Panel").GetComponent<Image>();
		currentColor.a =1;//change from 0 to 1
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < fadeInTime) {
			fadePanel.color = Color.red;
			float alphaChange = Time.deltaTime / fadeInTime;
			currentColor.a -=alphaChange;
			fadePanel.color = currentColor;
			//Debug.Log (currentColor.a.ToString());
		} else {
			gameObject.SetActive (false);
		}
		
	}
}
