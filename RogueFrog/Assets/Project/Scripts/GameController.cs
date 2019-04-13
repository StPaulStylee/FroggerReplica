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

	[SerializeField]
	private EnemyRow[ ] enemyRows;
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

		SetEnemiesOnLevel(0.2f);
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
		SetEnemiesOnLevel(0.2f);
	}

	private void OnPlayerMoved( )
	{
		if (player.transform.position.y > highestPosition) {
			highestPosition = player.transform.position.y;
			score++;
			ScoreText.text = "Score: " + score;
		}
	}

	private void InactivateEnemiesByPercentage(EnemyRow enemyRow, float keepActivePercentage ) {
		foreach (Enemy enemy in enemyRow.GetComponentsInChildren<Enemy>(true)) {
			float inactiveDeterminator = Random.value;
			if (inactiveDeterminator > keepActivePercentage) {
				enemy.gameObject.SetActive(false);
			}
		}
	}

	/// <summary>
	/// Set's the state of every enemy in each row to 'active'.
	/// </summary>
	/// <param name="enemyRow"></param>
	private void SetAllEnemiesToActive(EnemyRow enemyRow) {
		foreach (Enemy enemy in enemyRow.GetComponentsInChildren<Enemy>(true)) {
			enemy.gameObject.SetActive(true);
		}
	}

	private void SetEnemiesOnLevel(float keepActivePercentage) {
		if (enemyRows != null) {
			foreach (EnemyRow row in enemyRows) {
				SetAllEnemiesToActive(row);
				InactivateEnemiesByPercentage(row, keepActivePercentage);
				row.SetChildrenVelocity( );
			}
		}
	}

}
