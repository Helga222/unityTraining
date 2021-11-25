using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	public float health=150f;
	public float projectileSpeed=10f; 
	public GameObject projectile;
	public float shotsPerSecond = 0.5f;
	public int scoreValue = 150;
	private ScoreKeeper scoreKeeper;
	public AudioClip fireSound;
	public AudioClip deathSound;


	void Start(){
		scoreKeeper=GameObject.Find ("Score").GetComponent<ScoreKeeper> ();
	}

	void Update(){
		float probability = Time.deltaTime * shotsPerSecond;
		if (Random.value<probability){		
			Fire ();		
		}


	}

	void Fire(){
		Vector3 startPosition = transform.position+new Vector3(0,-1,0);
		GameObject  missile = Instantiate (projectile,startPosition,Quaternion.identity);
		missile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -projectileSpeed);
		AudioSource.PlayClipAtPoint (fireSound, transform.position,10);
	}

	void OnTriggerEnter2D(Collider2D collider){
		projectile missile=collider.gameObject.GetComponent<projectile> ();
		if (missile) {
			health-=missile.GetDamage ();
			missile.Hit ();
			if (health <= 0) {Die();}
		}
	}
	void Die(){
		AudioSource.PlayClipAtPoint (deathSound, transform.position,60);
		Destroy(gameObject);
		scoreKeeper.Score(scoreValue);
	}

}
