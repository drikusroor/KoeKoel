using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private int currentScore = 0;

	public GameObject textRenderer;
    private Canvas canvas;

	// Use this for initialization
	void Start () {
        canvas = FindObjectOfType<Canvas>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


	void DrawScore() {
        var texts = canvas.GetComponentsInChildren<Text>();
        texts[1].text = currentScore.ToString ();
	}

	public void AddScore(int scoreToAdd) {
		currentScore += scoreToAdd;
		DrawScore ();
	}
}
