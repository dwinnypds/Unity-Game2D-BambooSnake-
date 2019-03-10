using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour {
	public float kecepatan, batasBawah, batasAtas;
	public string axis;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float gerak = Input.GetAxis (axis) * kecepatan * Time.deltaTime;

		float nextPos = transform.position.y + gerak;
		if (nextPos > batasAtas) {
			gerak = 0;
		}
		if (nextPos < batasBawah) {
			gerak = 0;
		}
		transform.Translate (0, gerak, 0); 
		//transform.Translate (kecepatan = Time.deltaTime * Input.GetAxis ("Horizontal"),0,0);
	}

	/*
	void OnCollisionEnter (Collision col){
		foreach (ContactPoint contact in col.contacts) {
			if (contact.thisCollider == GetComponent<BoxCollider>()) {
				float calt = contact.point.x - transform.position.x;

				contact.otherCollider.GetComponent<Rigidbody> ().AddForce (200f*calt, 0,0);
			}
		}
	}*/
}
