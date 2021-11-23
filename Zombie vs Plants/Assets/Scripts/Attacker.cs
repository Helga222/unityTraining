using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {
	[Tooltip("Average number of seconds between appeareances")]
	public float seenEverySeconds;
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator anim;
	// Use this for initialization
	void Start () {
		//Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D> ();
		//myRigidbody.isKinematic = true;		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
 			anim = GetComponent<Animator> ();
			anim.SetBool ("IsAttacking", false);
		}

	}

	void OnTriggerEnter2D (){
		
		Debug.Log (name +" trigger enter");
	}

	public void SetSpeed(float speed) {
		currentSpeed = speed;
	}

	public void StrikeCurrentTarget(float damage) {
		//Debug.Log ("StrikeCurrentTarget"+damage);
		if (currentTarget) {
			Health health=currentTarget.GetComponent<Health>();
			if (health) {
				health.DealDamage (damage);
			}
		}
	}

	public void Attack(GameObject obj){
		currentTarget = obj;
	}
		
}
