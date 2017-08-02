using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koe : MonoBehaviour {

	public Sprite koeDood;
    public AudioClip impact;

    public AudioClip[] moos; 

    AudioSource audioSource;

	public bool isDood;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("MooSound", 1.5f, 3.5f);
        isDood = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void HandleGround(Collision2D other) {
		
		if (other.gameObject.tag == "Ground" && !isDood ) {
			isDood = true;
            audioSource.Stop();
            audioSource.PlayOneShot(impact, 0.8f);
			gameObject.GetComponent<SpriteRenderer> ().sprite = koeDood;
			gameObject.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
			gameObject.GetComponent<Collider2D> ().isTrigger = true;
		} else if (other.gameObject.tag == "Net" && !isDood )
        {
            isDood = true;
        }
	}

	void OnCollisionEnter2D(Collision2D other) {
		HandleGround (other);
	}

    void MooSound()
    {
        if (!isDood)
        {
            int mooSoundNumber = Random.Range(0, 3);
            audioSource.PlayOneShot(moos[mooSoundNumber], 0.4f);
        }
    }
}
