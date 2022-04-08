using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	private bool ballIsActive;
	private Vector3 ballPosition;
	private Vector2 ballInitialForce;
	Rigidbody2D rb;

	public AudioClip hitSound;
	AudioSource audioSource;

	public GameObject player;
	// Use this for initialization
	void Start () {
		// create the force
		ballInitialForce = new Vector2 (100.0f,300.0f);

		// set to inactive
		ballIsActive = false;

		// ball position
		ballPosition = transform.position;

		rb = GetComponent<Rigidbody2D> ();
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		// check for user input
		if (Input.GetButtonDown ("Jump") == true) {
			// check if is the first play
			if (!ballIsActive){
				// reset the force
				rb.isKinematic = false;

				// add a force
				rb.AddForce(ballInitialForce);

				// set ball active
				ballIsActive = !ballIsActive;
			}
		}

		if (!ballIsActive && player != null){
			// get and use the player position
			ballPosition.x = player.transform.position.x;

			// apply player X position to the ball
			transform.position = ballPosition;
		}

		if (ballIsActive && transform.position.y < -6) {
			ballIsActive = !ballIsActive;
			ballPosition.x = player.transform.position.x;
			ballPosition.y = -2.96f;
			transform.position = ballPosition;
			rb.isKinematic = true;

			player.SendMessage("TakeLife");
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (ballIsActive) {
			audioSource.PlayOneShot (hitSound);
		}
	}
}
