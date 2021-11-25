using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	public AudioClip startClip,gameClip,endClip;
	private AudioSource music;

	
	void Start () {
		//SceneManager.sceneLoaded += OnSceneLoaded;
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			print ("Music instance!");
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource> ();
			if (music) {
				music.Stop ();
			}
			music.clip = startClip;
			music.loop=true;
			music.Play ();
			SceneManager.sceneLoaded += OnSceneLoaded;
		}

	}
	/*void OnLevelWasLoaded(int level){
		Debug.Log ("MusicPlayer"+level);
		music.Stop();
		if (level == 0) {
			music.clip = startClip;
		} 
		if (level == 1) {
			music.clip = gameClip;
		} 
		if (level == 2) {
			music.clip = endClip;
		}
		music.loop = true;
		music.Play ();

	}*/
	void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		Debug.Log ("MusicPlayer"+scene.buildIndex);
		music.Stop();
		if (scene.buildIndex == 0) {
			music.clip = startClip;
		} 
		if (scene.buildIndex == 1) {
			music.clip = gameClip;
		} 
		if (scene.buildIndex == 2) {
			music.clip = endClip;
		}
		music.loop = true;
		music.Play ();
		
	}
}
