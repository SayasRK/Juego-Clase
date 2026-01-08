using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int lives = 3;
    public BallController ball;
    public TextMeshProUGUI livesText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        UpdateLivesUI(); // Mostrar vidas al empezar
    }

    public void LoseLife()
    {
        lives--;
        UpdateLivesUI();

        if (lives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            ball.ResetBall();
        }
    }

    void UpdateLivesUI()
    {
        livesText.text = "Vidas: " + lives;
    }
}
