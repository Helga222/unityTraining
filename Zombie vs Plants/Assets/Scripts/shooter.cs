using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour {

	public GameObject projectile, gun;
	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

	void Update(){
		if (IsAttackerAheadInLane ()) {
			animator.SetBool ("IsAttacking", true);
		} else {
			animator.SetBool ("IsAttacking", false);			
		}
	}

	void Start(){
		animator = GameObject.FindObjectOfType<Animator> ();		
		projectileParent = GameObject.Find ("Projectile");
		if (!projectileParent) {
			projectileParent= new GameObject("Projectile");

		}
		SetMyLaneSpawner ();
	}

	void SetMyLaneSpawner(){
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner> ();
		foreach (Spawner spawn in spawnerArray) {
			if (spawn.transform.position.y == transform.position.y) {
				myLaneSpawner = spawn;
				return;
			}
		}
			Debug.LogError (name + "can't find spawner in lane!");				
	}

	bool IsAttackerAheadInLane(){
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}
		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true;                                       
			}
			
		}
		return false;
	}

	private void Fire(){
		GameObject newProjectile=Instantiate (projectile);
		newProjectile.transform.parent=projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
		
}
