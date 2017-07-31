using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSpawner : MonoBehaviour {

	public GameObject[] KoeTypes;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnCow", 4f, 4f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnCow() {
		int randomNumber = Random.Range (0, 10);
		float deviance = Random.Range (-10f, 10f);

		GameObject spawnedCow;

		if (randomNumber == 0) {
			spawnedCow = GameObject.Instantiate (KoeTypes [2], transform) as GameObject;
		} else if (randomNumber < 4) {
			spawnedCow = GameObject.Instantiate (KoeTypes [1], transform) as GameObject;
		} else {
			spawnedCow = GameObject.Instantiate (KoeTypes [0], transform) as GameObject;
		}
		spawnedCow.transform.position += new Vector3 (deviance, 0f);
	}
}
