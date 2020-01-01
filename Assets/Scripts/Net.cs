using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net : MonoBehaviour {

	public Sprite netLeeg;
	public Sprite netVol;
    
    public AudioClip success;
    public AudioClip netSound;

    AudioSource audioSource;
    private ScoreManager scoreManager;


	private bool isNetVol = false;
	private string whichCow = "";

	// Use this for initialization
	void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void HandleCow(Collider2D other) {
		
		if (other.gameObject.tag == "Cow" && !isNetVol) {
            
			Koe koe = other.gameObject.GetComponent<Koe> ();

            if (!koe.isDood) {
                
                audioSource.PlayOneShot(netSound);
                isNetVol = true;
                whichCow = other.gameObject.name;

				this.GetComponent<SpriteRenderer>().sprite = netVol;	
				Object.Destroy (other.gameObject);
			}

		}
	}

	void HandleHouse(Collider2D other) {
		if (other.gameObject.tag == "House" && isNetVol) {

            audioSource.PlayOneShot(success);

            isNetVol = false;
            
			if (whichCow.Contains( "KoeNing") ) {
				scoreManager.AddScore (10);
			} else if (whichCow.Contains( "KoeSpeziale") ) {
				scoreManager.AddScore (3);
			} else {
				scoreManager.AddScore (1);
			}

			GetComponent<SpriteRenderer> ().sprite = netLeeg;
			whichCow = "";
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		HandleHouse (other);
		HandleCow (other);
	}
}
