using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Brick.breakableBricksCount = 0;
		SceneManager.LoadScene(name);

	}

	public void QuitGame(){
		Debug.Log("Quit request");
		Application.Quit();
	}

	public void LoadNextLevel(){
		Brick.breakableBricksCount = 0;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void CheckLevelCompleted() {
		if(Brick.breakableBricksCount <= 0){
			LoadNextLevel ();
		}
	}
}
