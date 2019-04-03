using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	// The size of a tile
	public float JumpDistance = 0.32f;

	private bool hasJumped;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

		if (!hasJumped) {
			// The frog didn't move
			if (horizontalMovement != 0) {
				transform.position = new Vector2(transform.position.x + (horizontalMovement > 0 ? JumpDistance : -JumpDistance), transform.position.y);
				hasJumped = true;
			}
			if (verticalMovement != 0) {
				transform.position = new Vector2(transform.position.x, transform.position.y + (verticalMovement > 0 ? JumpDistance : -JumpDistance));
				hasJumped = true;
			}
		} else {
			if (horizontalMovement == 0f && verticalMovement == 0f) {
				hasJumped = false;
			}
		}
	}
}
