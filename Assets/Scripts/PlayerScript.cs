using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public float playerVelocity;
	private Vector3 playerPosition,playerScale;
	public float boundary;
	private int playerLives;
	private int playerPoints;

	public AudioClip pointSound;
	public AudioClip lifeSound;

	public GameObject canvas;
	public static bool gainLife=false;
	public static bool gainExtend=false;

	Scene scene;

	AudioSource audio;

	// Use this for initialization
	void Start () {
		playerPosition = gameObject.transform.position;
		playerScale = gameObject.transform.localScale;
		Time.timeScale = 1;
		playerLives = 3;
		playerPoints = 0;
		audio = GetComponent<AudioSource> ();
		canvas.SetActive (false);
		scene = SceneManager.GetActiveScene ();
	}
	
	// Update is called once per frame
	void Update () {
		playerPosition.x += Input.GetAxis ("Horizontal") * playerVelocity;

		if (Input.GetKeyDown (KeyCode.Escape)) {
			PlayerPrefs.SetString ("LevelSave", Application.loadedLevelName);
			SceneManager.LoadScene ("MainMenu");
		}

		transform.position = playerPosition;

		//boundary
		if (playerPosition.x < -boundary) {
			transform.position = new Vector3 (-boundary, playerPosition.y, playerPosition.z);
		}
		if (playerPosition.x > boundary) {
			transform.position = new Vector3(boundary, playerPosition.y, playerPosition.z);     
		}

		if (gainLife) {
			playerLives++;
			gainLife = false;
		}

		if (gainExtend) {
			playerScale = new Vector3 (gameObject.transform.localScale.x+0.4f, gameObject.transform.localScale.y,
				gameObject.transform.localScale.z);
			gainExtend = false;
		}
		gameObject.transform.localScale = playerScale;

		WinLose ();
	}

	void addPoints(int points){
		playerPoints += points;
		audio.PlayOneShot (pointSound);
	}

	void OnGUI(){
		GUI.Label (new Rect(70.0f,23.0f,200.0f,200.0f),"Lives: " + playerLives + "  Score: " + playerPoints);
	}

	void TakeLife(){
		playerLives--;
		audio.PlayOneShot (lifeSound);
	}

	void WinLose(){
		if (playerLives == 0) {
			Application.LoadLevel ("GameOver");
		}

		// blocks destroyed
		if ((GameObject.FindGameObjectsWithTag ("Block")).Length == 0) {
			Time.timeScale = 0;
			canvas.SetActive (true);
			// check the current level
			if (scene.name == "Level1" && Input.GetKeyDown (KeyCode.Q)) {
				SceneManager.LoadScene("Level2");
			} 
			else if (scene.name== "Level2" && Input.GetKeyDown (KeyCode.Q)) {
				SceneManager.LoadScene("Level3");
			}
			else if (scene.name== "Level3" && Input.GetKeyDown (KeyCode.Q)) {
				SceneManager.LoadScene("MainMenu");
			}
		}
	}
}
