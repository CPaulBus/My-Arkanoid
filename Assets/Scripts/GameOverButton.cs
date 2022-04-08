using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Retry(){
		string levelName = PlayerPrefs.GetString ("LevelSave");
		 SceneManager.LoadScene("Level1");
	}

	public void Quit(){
		SceneManager.LoadScene ("MainMenu");
	}
}
