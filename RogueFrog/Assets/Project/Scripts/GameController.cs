using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public Player player;
	public Text ScoreText;
	public Text LevelText;

	private float highestPosition;
	private int score = 0;
	private int level = 1;
    // Start is called before the first frame update
    void Start()
    {
		player.OnPlayerMoved += OnPlayerMoved;
		player.OnPlayerEscaped += OnPlayerEscaped;

		highestPosition = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnPlayerEscaped( ) 
	{
		highestPosition = player.transform.position.y;
		level++;
		LevelText.text = "Level: " + level;
	}

	private void OnPlayerMoved( )
	{
		if (player.transform.position.y > highestPosition) {
			highestPosition = player.transform.position.y;
			score++;
			ScoreText.text = "Score: " + score;
		}
	}
}
