using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	// 10 Enemy Rows; 23 enemies per row

	public float Speed = 1f;
	// Start is called before the first frame update
	void Start()
    {

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

	public void SetEnemyToInactive(float keepActivePercentage) {
		float inactiveDeterminator = Random.value;
		if (inactiveDeterminator > keepActivePercentage) {
			gameObject.SetActive(false);
		}
	}
}
