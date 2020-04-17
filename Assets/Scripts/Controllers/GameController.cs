using UnityEngine;
using TMPro;    // TextMeshPro library

public class GameController : MonoBehaviour
{
    // Public & private fields
    public static int PlayerScore { get { return playerScore; } }
    public static int playerScore;
    [SerializeField] private TextMeshProUGUI scoreText;

    //  Private methods 
    private void Start()
    {
        playerScore = 0;
        UpdateScore();
    }
    //  Listeners
    private void OnEnable()
    {
        Enemy.EnemyKilledEvent += OnEnemyKilledEvent;
        ReflectEnemy.PassiveEnemyKilledEvent += OnPassiveEnemyKilledEvent;
    }
    private void OnDisable()
    {
        Enemy.EnemyKilledEvent -= OnEnemyKilledEvent;
        ReflectEnemy.PassiveEnemyKilledEvent -= OnPassiveEnemyKilledEvent;
    }

    //  Adds enemy value to score
    private void OnEnemyKilledEvent(Enemy enemy)
    {
        playerScore += enemy.ScoreValue;
        UpdateScore();
    }
    //  Adds passive enemy value to score
    private void OnPassiveEnemyKilledEvent(ReflectEnemy passiveEnemy)
    {
        playerScore += passiveEnemy.ScoreValue;
        UpdateScore();
    }

    // Method to update score
    private void UpdateScore()
    {
        // output to screen
        // playerscore is /10 decided last minute that
        // scores were large, only changing output to user
        int outputPlayerScore = playerScore / 10;
        scoreText.text = outputPlayerScore.ToString();
    }
}
