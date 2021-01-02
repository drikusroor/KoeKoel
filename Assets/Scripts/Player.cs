using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float moveSpeed;

    private AudioSource audioSource;

    private Vector3 horizontalMove;

    public PlayerState state = PlayerState.None;

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

        Debug.Log(state);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 0)
            {

                if ((state & PlayerState.Running) == 0)
                {
                    state |= PlayerState.Running;
                }

                if ((state & PlayerState.Moving) != 0)
                {
                    stamina -= runningCost;
                }

            } else
            {
                state &= ~PlayerState.Running;
            }

        } else
        {
            if (state.HasFlag(PlayerState.Running))
            {
                state &= ~PlayerState.Running;
            }
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!audioSource.isPlaying) audioSource.Play();

            if (state.HasFlag(PlayerState.FaceRight))
            {
                Flip();
                state &= ~PlayerState.FaceRight;
            }
            
            if (!state.HasFlag(PlayerState.Moving)) state |= PlayerState.Moving;

            var speedModifier = state.HasFlag(PlayerState.Running) ? runningSpeedModifier : 1f;
            var currentPos = transform.position.x;

            transform.position -= new Vector3(horizontalMove.x * speedModifier, 0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!audioSource.isPlaying) audioSource.Play();

            if (!state.HasFlag(PlayerState.FaceRight))
            {
                Flip();
                state |= PlayerState.FaceRight;
            }

            if (!state.HasFlag(PlayerState.Moving)) state |= PlayerState.Moving;

            var speedModifier = state.HasFlag(PlayerState.Running) ? runningSpeedModifier : 1f;
            var currentPos = transform.position.x;

            transform.position += new Vector3(horizontalMove.x * speedModifier, 0f);
        }
        else
        {
            if (state.HasFlag(PlayerState.Moving)) state &= ~PlayerState.Moving;

            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}

[Flags]
public enum PlayerState
{
    None = 0,
    FaceRight = 1,
    Moving = 2,
    Running = 4,
    CarriesFlag = 8
}