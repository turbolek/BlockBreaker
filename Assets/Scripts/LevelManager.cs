using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {


	public void LoadLevel (string name){
		Brick.breakableCounter = 0;
		Debug.Log("Level load requested for " + name);
		Application.LoadLevel(name);
	}
	
	public void QuitRequest () {
		Debug.Log("Quit requested");
		Application.Quit();
	}
	
	public void LoadNextLevel () {
		Brick.breakableCounter = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed() {
		if (Brick.breakableCounter <=0 ) {
			LoadNextLevel();
		}
	}
}
