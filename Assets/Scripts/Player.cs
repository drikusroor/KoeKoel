using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float moveSpeed;

    private AudioSource audioSource;

    private Vector3 horizontalMove;
    private bool faceLeft = true;
    private bool isMoving = false;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
		horizontalMove = new Vector3 (moveSpeed, 0f);
	}

	void Flip() {
		Vector3 newScale = transform.localScale;
		newScale.x *= -1;
		transform.localScale = newScale;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void ResetMoveSpeed ()
    {
        SetMoveSpeed();
    }

    public void SetMoveSpeed(float modifier = 1f)
    {
        horizontalMove = new Vector3(moveSpeed * modifier, 0f);
    }

    void Move ()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!audioSource.isPlaying) audioSource.Play();
            if (!faceLeft)
            {
                Flip();
                faceLeft = true;
            }
            transform.position -= horizontalMove;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!audioSource.isPlaying) audioSource.Play();
            if (faceLeft)
            {
                Flip();
                faceLeft = false;
            }
            transform.position += horizontalMove;
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
