using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {

	public float paddleSpeed = 18f;
	public string axis;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (paddleSpeed = Time.deltaTime * Input.GetAxis ("Horizontal"), 0, 0);
	}

	void OnCollisionEnter (Collision col){
		foreach (ContactPoint contact in col.contacts) {
			if (contact.thisCollider == GetComponent<BoxCollider>()) {
				float calt = contact.point.x - transform.position.x;

				contact.otherCollider.GetComponent<Rigidbody> ().AddForce (200f*calt, 0,0);
			}
		}
	}
}
