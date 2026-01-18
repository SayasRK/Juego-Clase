using UnityEngine;

public class PowerUp_Escopeta : MonoBehaviour
{
    public float fallSpeed = 2f;
    public GameObject ballPrefab;

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Paddle"))
        {
            SpawnShotgunBalls(other.transform.position);

            // Añade 3 vidas 
            GameManager.Instance.AddLife(3);

            Destroy(gameObject);
        }
    }

    void SpawnShotgunBalls(Vector3 paddlePos)
    {
        // Posicion un poco por encima de la pala
        Vector3 spawnPos = paddlePos + Vector3.up * 0.6f;

        // Direcciones en forma de "arco"
        Vector2[] directions =
        {
            new Vector2(-0.6f, 1f).normalized,
            new Vector2(0f, 1f).normalized,
            new Vector2(0.6f, 1f).normalized
        };

        foreach (Vector2 dir in directions)
        {
            GameObject ball = Instantiate(ballPrefab, spawnPos, Quaternion.identity);
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.linearVelocity = dir * 8f; // misma velocidad que las otras bolas
            }
        }
    }
}
