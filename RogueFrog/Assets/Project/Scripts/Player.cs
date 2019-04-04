using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	// The size of a tile
	public float JumpDistance = 0.32f;

	private bool hasJumped;
	private Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
		startingPosition = transform.position;
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
		// The logic below keeps the frog within the bounds of the map
		// We divide by 100 to get the pixel value into Unity values
		// REmember to make the 100 and 2 divisors into a float because Screen.height and width are ints
		// and dividing an int by a float will ensure a float is returned
		// Bottom bound
		if (transform.position.y < -(Screen.height / 100f) / 2f) {
			transform.position = new Vector2(transform.position.x, transform.position.y + JumpDistance);
		}
		// Top bound - Notice that we are moving the frog back to it's starting position
		if (transform.position.y > (Screen.height / 100f) / 2f) {
			transform.position = startingPosition;
		}
		// Left Bound
		if (transform.position.x < -(Screen.width / 100f) / 2f) {
			transform.position = new Vector2(transform.position.x + JumpDistance, transform.position.y);
		}
		// Right bound
		if (transform.position.x > (Screen.width / 100f) / 2f) {
			transform.position = new Vector2(transform.position.x - JumpDistance, transform.position.y);
		}
	}
}
