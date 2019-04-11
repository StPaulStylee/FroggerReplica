using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public Player player;
	public Text ScoreText;
	public Text LevelText;
	public Text GameOverText;
	public float DifficultyMultiplier = 1.2f;

	private float highestPosition;
	private int score = 0;
	private int level = 1;
	private float restartTimer = 3f;
    // Start is called before the first frame update
    void Start()
    {
		player.OnPlayerMoved += OnPlayerMoved;
		player.OnPlayerEscaped += OnPlayerEscaped;

		highestPosition = player.transform.position.y;
		GameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		if (player == null) {
			GameOverText.gameObject.SetActive(true);
			restartTimer -= Time.deltaTime;
			if (restartTimer <= 0f) {
				SceneManager.LoadScene("Game");
			}
		}
	}

	private void OnPlayerEscaped( ) 
	{
		highestPosition = player.transform.position.y;
		level++;
		LevelText.text = "Level: " + level;
		//foreach (EnemyRow enemyRow in GetComponentsInChildren<EnemyRow>( )) {
		//	enemyRow.Speed *= DifficultyMultiplier;
		//}
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
