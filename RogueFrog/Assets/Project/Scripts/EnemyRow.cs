using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRow : MonoBehaviour
{
	// 10 Enemy Rows; 23 enemies per row
	public float Speed = 1f;

	//private Component[ ] enemies;

	// Start is called before the first frame update
	void Start()
    {
		float velocityDeterminator = Random.value;
		//enemies = GetComponentInChildren<Enemy>( );
		foreach (Enemy enemy in GetComponentsInChildren<Enemy>( )) {
			enemy.GetComponent<Rigidbody2D>( ).velocity = new Vector2(velocityDeterminator > 0.5f ? Speed : -Speed, 0);
		};
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
