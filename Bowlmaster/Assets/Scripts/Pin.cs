using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {
	public float standingTreshold;

	private float distToRaise=0.4f;
	private Rigidbody rigidBody; 

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		//print (name + IsStanding ());
		
	}
	public bool IsStanding () {
		
		Vector3 rotationInEuler = transform.localEulerAngles;
		//Quaternion rotation = Quaternion.Euler(rotationInEuler);
		//rotationInEuler = rotation.eulerAngles;
		float tiltInX = rotationInEuler.x;
		float tiltInZ = rotationInEuler.z;

		tiltInX = ConvertAngle (tiltInX);
		tiltInZ = ConvertAngle (tiltInZ);
		tiltInX = Mathf.Abs (tiltInX);
		tiltInZ = Mathf.Abs (tiltInZ);

		if (tiltInX >= standingTreshold || tiltInZ >= standingTreshold) /*|| (transform.position.y>-1)*/{
			return false;	//иногда улетает за пределы игрового пространства, тогда неверно вчисляет кол-во стоящих кегель	
		} else {
			return true;
		}
	}


	float ConvertAngle (float angle){
		angle %= 360;
		angle = angle > 180 ? angle-360 : angle;
		return angle;
		
	}

	public void RaiseIfStanding() {
			if (IsStanding ()) {
				rigidBody.useGravity = false;
				transform.Translate (new Vector3 (0, distToRaise, 0), Space.World);
				transform.rotation = Quaternion.Euler (0,0,0);
			}
	}

	public void Lower() {
		transform.Translate (new Vector3 (0, -distToRaise, 0), Space.World);
		rigidBody.useGravity = true;
		print ("lower");
	}


}
