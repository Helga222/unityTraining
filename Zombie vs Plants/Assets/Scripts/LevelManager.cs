using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public float autoLoadNextLevelAfter;

	void Start(){
		if (SceneManager.GetActiveScene ().buildIndex == 0) {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);}

	}

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
		//Application.LoadLevel (Application.loadedLevel+1);
	}
	public void LoadPreviousLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex-1);
		//Application.LoadLevel (Application.loadedLevel+1);
	}

}
