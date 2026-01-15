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

    // Número de bolas activas en pantalla
    public int activeBalls = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Time.timeScale = 1f;
        UpdateLivesUI();
        UpdateScoreUI();

        // Al empezar la partida siempre hay una bola
        SpawnBall();
    }


    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public void AddLife(int amount = 1)
    {
        lives += amount;
        UpdateLivesUI();
    }


    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    
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

    public void RegisterBall()
    {
        activeBalls++;
    }

    public void BallDestroyed()
    {
        activeBalls--;

        // Si ya no queda ninguna bola, se pierde una vida
        if (activeBalls <= 0)
        {
            LoseLife();
        }
    }


    void LoseLife()
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
