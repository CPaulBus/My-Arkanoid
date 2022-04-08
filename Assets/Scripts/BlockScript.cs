using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {
	public int hitsToKill;
	public int points;
	private int numberOfHits;
	public bool haspowerup=false;
	public GameObject pwrups;

	// Use this for initialization
	void Start () {
		numberOfHits = 0;
		if(haspowerup)
			pwrups.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter2D(Collision2D collision){

		if (collision.gameObject.tag == "Ball"){
			numberOfHits++;

			if (numberOfHits == hitsToKill){
				GameObject player = GameObject.FindGameObjectWithTag ("Player");
				player.SendMessage ("addPoints", points);
				if(haspowerup)
					pwrups.SetActive (true);
				// destroy the object
				Destroy(this.gameObject);
			}
		}
	}
}
