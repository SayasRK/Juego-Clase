using UnityEngine;

public class PowerUp_MultiplicarBolas : MonoBehaviour
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
            MultiplyBalls();
            Destroy(gameObject);
        }
    }

    void MultiplyBalls()
    {
        if (ballPrefab == null)
        {
            Debug.LogError("PowerUp_MultiplicarBolas: ballPrefab no asignado.");
            return;
        }

        //Bolas actuales en pantalla
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        int ballCount = balls.Length;

        //Se añaden tantas vidas como bolas hayan en pantalla
        GameManager.Instance.AddLife(ballCount);

        // Duplicamos cada bola
        foreach (GameObject ball in balls)
        {
            Vector3 spawnPos = ball.transform.position;

            GameObject newBall = Instantiate(ballPrefab, spawnPos, Quaternion.identity);

            Rigidbody2D rb = newBall.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 randomDir = new Vector2(
                    Random.Range(-1f, 1f),
                    Random.Range(0.5f, 1f)
                ).normalized;

                rb.linearVelocity = randomDir * 8f;
            }
        }
    }
}

