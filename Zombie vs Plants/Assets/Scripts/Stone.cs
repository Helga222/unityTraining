using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {
	private Animator anim;

	void Start(){
		anim = GetComponent<Animator> ();
	}
	void OnTriggerStay2D (Collider2D collider){
		/*GameObject obj = collider.gameObject;
		if (!obj.gameObject.GetComponent<Attacker> ()) {
			return;
		}*/
		Attacker attacker = collider.gameObject.GetComponent<Attacker> ();
		if (attacker) {
			anim.SetTrigger ("underAttack trigger");
		}
	}

}
