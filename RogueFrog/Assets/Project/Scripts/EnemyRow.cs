using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRow : MonoBehaviour
{
	void Start()
    {
		SetChildrenVelocity( );
	}

	// Update is called once per frame
	void Update()
    {

	}
	/// <summary>
	///  Get's all of the active enemies that are children of the EnemyRow by locating the enemies
	///  rigid body component. Set's each enemy velocity dependent upon the value of a random float
	///  generated between 0 and 1.
	///  <remarks>NOTE: 10 Enemy Rows; 23 enemies per row per map</remarks>
	/// </summary>
	public void SetChildrenVelocity( ) {
		float velocityDeterminator = Random.value;
		foreach (Enemy enemy in GetComponentsInChildren<Enemy>( )) {
			enemy.GetComponent<Rigidbody2D>( ).velocity = new Vector2(velocityDeterminator > 0.5f ? enemy.Speed : -enemy.Speed, 0);
		};
	}
}
