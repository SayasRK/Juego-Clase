using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int lives = 3;
    public int score = 0;
    public int remainingBricks = 0;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    public GameObject winText;
    public GameObject ballPrefab;
    public Transform ballSpawnPoint;

    public bool IsRestarting = false;



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
            WinGame();
        }
    }


    // ---------- LIVES ----------
    public void LoseLife()
    {
        lives--;
        UpdateLivesUI();

        if (lives <= 0)
        {
            RestartGame();
            return;
        }

        SpawnBall();
    }


    void UpdateLivesUI()
    {
        if (livesText != null)
            livesText.text = "Lives: " + lives;
    }

    void SpawnBall()
    {
        Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);
    }

    void RestartGame()
    {
        IsRestarting = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void WinGame()
    {
        Time.timeScale = 0f;

        if (winText != null)
            winText.SetActive(true);
    }

}
