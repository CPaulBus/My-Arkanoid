using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			if (this.CompareTag ("Lives")) {
				PlayerScript.gainLife = true;
				Destroy (this.gameObject);
			}
			if (this.CompareTag ("Extend")) {
				PlayerScript.gainExtend = true;
				Destroy (this.gameObject);
			}
		}
	}
}
