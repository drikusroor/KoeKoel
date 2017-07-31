using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float moveSpeed;
	private Vector3 horizontalMove;
	private bool faceLeft = true;

	// Use this for initialization
	void Start () {
		horizontalMove = new Vector3 (moveSpeed, 0f);
	}

	void Flip() {
		Vector3 newScale = transform.localScale;
		newScale.x *= -1;
		transform.localScale = newScale;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.LeftArrow)) {
			if (!faceLeft) {
				Flip ();
				faceLeft = true;
			}
			transform.position -= horizontalMove;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			if (faceLeft) {
				Flip ();
				faceLeft = false;
			}
			transform.position += horizontalMove;
		}

	}
}
