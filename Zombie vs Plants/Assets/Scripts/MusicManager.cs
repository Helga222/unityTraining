using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {
	public AudioClip[] levelMusicChangeArray;
	private AudioSource music;


	/*void OnAwake () {
		GameObject.DontDestroyOnLoad(gameObject);
		Debug.Log ("OnAwake");
	}*/ // не работает DontDestroyOnLoad(gameObject);

	void Start () {
		GameObject.DontDestroyOnLoad(gameObject);		
		Debug.Log ("In Start");
		music=GetComponent<AudioSource> ();
		Debug.Log ("After Music");
		SceneManager.sceneLoaded += OnSceneLoaded;				
	}


	void Update () {
		
	}
	void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		Debug.Log ("OnSceneLoaded:"+music.ToString());
		AudioClip thisLevelMusic=levelMusicChangeArray[scene.buildIndex];
		if (thisLevelMusic) {
			music.clip = thisLevelMusic;
			music.loop=true;
			music.Play ();
			music.volume = PlayerPrefsManager.GetMasterVolume ();
		}
	}

	public void SetVolume (float value){
		music.volume = value;
		
	}
}
