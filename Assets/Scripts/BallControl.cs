using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BallControl : MonoBehaviour {

	public int force;
	Rigidbody2D rgdbd;

	//score
	int scoreP1, scoreP2;
	Text scoreUIP1, scoreUIP2;

	//GameOver
	GameObject panelSelesai;
	Text txWinner;

	//sound
	AudioSource audio;
	public AudioClip hitBallSound;


	// Use this for initialization
	void Start () {
		rgdbd = GetComponent <Rigidbody2D> ();
		Vector2 arah = new Vector2 (2, 0).normalized;
		rgdbd.AddForce (arah * force);

		//score
		scoreP1 = 0;
		scoreP2 = 0;
		scoreUIP1 = GameObject.Find ("Score1").GetComponent<Text> ();
		scoreUIP2 = GameObject.Find ("Score2").GetComponent<Text> ();

		//gameover
		panelSelesai = GameObject.Find ("PanelSelesai");
		panelSelesai.SetActive (false);

		//sound
		audio = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D (Collision2D coll){
		//pantulan bola
		if (coll.gameObject.name == "Player1" || coll.gameObject.name == "Player2"){
			float sudut = (transform.position.y - coll.transform.position.y) * 5f;
			Vector2 arah = new Vector2 (rgdbd.velocity.x, sudut).normalized;
			rgdbd.velocity = new Vector2 (0, 0);
			rgdbd.AddForce (arah * force * 2);
		}

		if (coll.gameObject.name == "TepiKanan")
		{
			scoreP1 += 1;
			TampilkanScore ();
			if (scoreP1 == 5) {
				panelSelesai.SetActive (true);
				txWinner = GameObject.Find ("WIN").GetComponent<Text> ();
				txWinner.text = "Player 1 WIN!";
				Destroy (gameObject);
				return;
			}

			ResetBola();
			Vector2 arah = new Vector2(2, 0).normalized;
			rgdbd.AddForce(arah * force);
		}
		if (coll.gameObject.name == "TepiKiri")
		{
			scoreP2 += 1;
			TampilkanScore ();
			if (scoreP2 == 5) {
				panelSelesai.SetActive (true);
				txWinner = GameObject.Find ("WIN").GetComponent<Text> ();
				txWinner.text = "Player 2 WIN!";
				Destroy (gameObject);
				return;
			}

			ResetBola();
			Vector2 arah = new Vector2(-2, 0).normalized;
			rgdbd.AddForce(arah * force);
		}

		//brick
		if (coll.transform.CompareTag("bentengB")){
			Destroy (coll.gameObject);
		}
			
		//sound
		audio.PlayOneShot(hitBallSound);
	}

	void ResetBola(){
		transform.localPosition = new Vector2 (0, 0);
		rgdbd.velocity = new Vector2 (0, 0);
	}

	void TampilkanScore(){
		Debug.Log ("Score P1: " + scoreP1 + "Score P2: " + scoreP2);
		scoreUIP1.text = scoreP1 + "";
		scoreUIP2.text = scoreP2 + "";
	}


}
