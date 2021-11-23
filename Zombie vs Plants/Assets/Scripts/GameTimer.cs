using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float levelSeconds=100;
	private Slider slider;
	private AudioSource audioSourse;
	private bool isEndOfLevel=false;
	private LevelManager levelManager;
	private GameObject winLabel;
	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
		audioSourse = GetComponent<AudioSource> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		FindYouWin ();
		winLabel.SetActive(false);
	}

	void FindYouWin ()
	{
		winLabel = GameObject.Find ("You Win");
		if (!winLabel) {
			Debug.LogWarning ("Please create You Win object!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelSeconds;
		if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel) {
			audioSourse.Play ();
			winLabel.SetActive(true);
			Invoke ("LoadNextLevel",audioSourse.clip.length);
			isEndOfLevel = true;
		}
		
	}

	void LoadNextLevel (){
		levelManager.LoadNextLevel ();

	}
}
