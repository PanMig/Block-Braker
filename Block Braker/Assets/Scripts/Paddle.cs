using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoplay = false; //made public so it can be modified by the editor.

	private Ball ball;
	private float minX = 1.86f, maxX = 15.00f;

	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, -2.0f);

		//used for the Autoplay function
		ball = GameObject.FindObjectOfType<Ball> ();
	}

	// Update is called once per frame
	void Update () {
		if (!autoplay) {
			MoveWithMouse ();
		} 
		else {
			Autoplay ();
		}
		
	}

	// once called the game is playing by itself,used for testing purposes.
	public void Autoplay(){

		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, -2.0f);

		Vector3 planetPos = ball.transform.position;

		paddlePos.x = Mathf.Clamp(planetPos.x,minX,maxX);

		this.transform.position = paddlePos;
	}

	public void MoveWithMouse(){

		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, -2.0f);

		float mouseInBlocks=(Input.mousePosition.x / Screen.width * 16);

		paddlePos.x = Mathf.Clamp(mouseInBlocks,minX,maxX);

		this.transform.position = paddlePos;

	}
}
