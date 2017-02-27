using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour {

	private int maxBrickHits;
	private int timesBrickWasHit;
	private LevelManager levelManager;
	private bool isBreakable;

	public static int breakableBricksCount = 0;
	public Sprite[] brickSprites;

	// Use this for initialization
	void Start () {
		//find a breakable brick and increment the number of breakable bricks in the scene.
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableBricksCount++;
		}


		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		timesBrickWasHit = 0;
	}

	void OnCollisionEnter2D(Collision2D coll){

		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits(){

		/*maxHits shows how many hits a brick can handle before being destroyed. 
		  It is defined by + 1 because the array starts to count from zero. */
		maxBrickHits = brickSprites.Length + 1;  
		timesBrickWasHit++;

		if (timesBrickWasHit >= maxBrickHits) {
			breakableBricksCount--;
			levelManager.CheckLevelCompleted ();
			Destroy (gameObject);
		} 
		else {
			LoadNextSprite ();
		}
	}

	void LoadNextSprite(){
		int spriteIndex = timesBrickWasHit - 1;

		if (brickSprites [spriteIndex] != null) this.GetComponent<SpriteRenderer> ().sprite = brickSprites [spriteIndex];
		else Debug.Log ("Sprite is missing from the brickSprite array");
	}

}
