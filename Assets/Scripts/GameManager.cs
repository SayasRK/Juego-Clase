using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int lives = 3;
    public int score = 0;
    public int remainingBricks = 0;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        UpdateLivesUI();
        UpdateScoreUI();
    }

    // ---------- SCORE ----------
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    // ---------- BRICKS ----------
    public void RegisterBrick()
    {
        remainingBricks++;
    }

    public void BrickDestroyed(int points)
    {
        remainingBricks--;
        AddScore(points);

        if (remainingBricks <= 0)
        {
            Debug.Log("YOU WIN");
        }
    }

    // ---------- LIVES ----------
    public void LoseLife()
    {
        lives--;
        UpdateLivesUI();

        if (lives <= 0)
        {
            Debug.Log("GAME OVER");
        }
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
            livesText.text = "Lives: " + lives;
    }
}
