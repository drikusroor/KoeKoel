using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koe : MonoBehaviour {

	public Sprite koeDood;

	private bool isDood = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void HandleGround(Collision2D other) {
		print (other.gameObject.tag);
		if (other.gameObject.tag != "Net") {
			isDood = true;
			gameObject.GetComponent<SpriteRenderer> ().sprite = koeDood;
			gameObject.GetComponent<Collider2D> ().isTrigger = true;
			gameObject.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
				HandleGround (other);
	}

	public bool IsDood() {
		return isDood;
	}
}
