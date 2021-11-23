using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;

	void Update(){
		foreach (GameObject thisAttacker in attackerPrefabArray) {
			if (isTimeToSpawn (thisAttacker)) {
				Spawn (thisAttacker);
			}
		}
	}

	void Spawn(GameObject myGameObject){
		GameObject myAttacker = Instantiate (myGameObject);
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}

	bool isTimeToSpawn(GameObject attackerGameObject){
		Attacker attacker = attackerGameObject.GetComponent<Attacker> ();
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;

		if (Time.deltaTime > spawnsPerSecond) {
			Debug.Log ("Impossible to spawn");
		}

		float treshold = Time.deltaTime * spawnsPerSecond / 5;
		return (Random.value < treshold);

	}	
}
