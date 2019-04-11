using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	// 10 Enemy Rows; 23 enemies per row

	//public float Speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
		// If you want to test different speeds during gameplay you will need to have this called in Update()
		//float velocityDeterminator = Random.value;
		//GetComponent<Rigidbody2D>( ).velocity = new Vector2(velocityDeterminator > 0.5f ? Speed : -Speed, 0 );
	}

	// Update is called once per frame
	void Update()
    {
		// Moving to the right... If enemy postion is greater than the right bound (+1;  2.6)
		if (transform.position.x > (Screen.width / 100f) / 2f + 1f) {
			transform.position = new Vector3(-transform.position.x + 1f, transform.position.y);
		// Moving to the left... If enemy position is less than the left bound (-1; -2.6)
		} else if (transform.position.x < -(Screen.width / 100f) / 2f - 1f) {
			transform.position = new Vector3(-transform.position.x - 1f, transform.position.y);
		}
	}
}
