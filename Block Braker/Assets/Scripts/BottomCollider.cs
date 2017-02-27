using UnityEngine;
using System.Collections;

public class BottomCollider : MonoBehaviour {

	private LevelManager levelManager;
	private string levelName="Lose";

	void Start(){
		/*this line programmatically finds the levelManager object,
		if this is not done,the levelManager reference must have been initialized for the editor*/
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnTriggerEnter2D(Collider2D trigger){
		/*change the number of bricks to '0' in case you 
		 * lose because the game reloads again and the static keeps the previous values */
		Brick.breakableBricksCount = 0; 

		levelManager.LoadLevel (levelName);
	}

}
