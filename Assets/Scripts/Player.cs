using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float moveSpeed;

    private AudioSource audioSource;

    private Vector3 horizontalMove;
    private bool faceLeft = true;
    private bool isMoving = false;

    public float stamina;
    public float staminaTotal = 100f;
    public float staminaRegenRate;

    private bool isRunning = false;
    public float runningSpeedModifier;
    public float runningCost;

    // Use this for initialization
    void Start () {
        stamina = staminaTotal;
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
        if (stamina < 100f)
        {
            stamina += staminaRegenRate;
        } else
        {
            stamina = 100f;
        }
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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 0)
            {

                if (!isRunning)
                {
                    isRunning = true;
                }

                if (isMoving)
                {
                    stamina -= runningCost;
                }

            } else
            {
                isRunning = false;
            }

        } else
        {
            if (isRunning)
            {
                isRunning = false;
            }
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!audioSource.isPlaying) audioSource.Play();
            if (!faceLeft)
            {
                Flip();
                faceLeft = true;
            }
            if (!isMoving) isMoving = true;
            transform.position -= horizontalMove * (isRunning ? runningSpeedModifier : 1f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!audioSource.isPlaying) audioSource.Play();
            if (faceLeft)
            {
                Flip();
                faceLeft = false;
            }
            if (!isMoving) isMoving = true;
            transform.position += horizontalMove * (isRunning ? runningSpeedModifier : 1f);
        }
        else
        {
            if (isMoving) isMoving = false;
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
