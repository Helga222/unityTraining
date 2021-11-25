using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	void OnTriggerExit (Collider col){
		GameObject tingLeft = col.gameObject;
		if (/*tingLeft.GetComponent<Ball> () ||*/ tingLeft.GetComponent<Pin>()) {
			Destroy (tingLeft);
		}

	} 
}
