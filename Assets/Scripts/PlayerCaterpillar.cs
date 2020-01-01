using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCaterpillar : MonoBehaviour {

    private Player player;

	// Use this for initialization
	void Start () {
        player = transform.parent.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void HandleCow(Collider2D other)
    {
        if (other.gameObject.tag == "Cow")
        {

            Koe koe = other.gameObject.GetComponent<Koe>();

            if (koe.isDood)
            {
                player.SetMoveSpeed(.6f);
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        HandleCow(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        player.SetMoveSpeed();
    }
}
