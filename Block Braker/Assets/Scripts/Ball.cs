using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private bool gameStarted = false;
    private Vector3 distanceBallToPaddle;
    private Rigidbody2D rgdBody;
    private Paddle paddle;
    private float minRange = -0.3f; 
	private float maxRange = 0.3f;

    void Awake(){
		rgdBody = GetComponent<Rigidbody2D> ();
	}

	void Start () {
		
        /* we have only one paddle object and we want to initialize it programmatically
		to make the process of dublicating levels easier*/
		paddle = GameObject.FindObjectOfType<Paddle> ();
		
        //finds how far the ball is from the paddle
		distanceBallToPaddle = this.transform.position - paddle.transform.position;
	}

	void Update () {
		if (gameStarted == false) {
			this.transform.position = paddle.transform.position + distanceBallToPaddle;

			if(Input.GetMouseButtonDown(0)){
				this.rgdBody.velocity = new Vector2 (3.0f,11.5f);
				gameStarted = true;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		Vector2 tweak = new Vector2 (Random.Range (minRange,maxRange), Random.Range (minRange,maxRange));

		if (gameStarted) {
			this.GetComponent<Rigidbody2D>().velocity += tweak;
			GetComponent<AudioSource> ().Play ();
		}
	}

}