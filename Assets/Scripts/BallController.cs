using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 8f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Registramos esta bola como activa
        GameManager.Instance.RegisterBall();

        LaunchBall();
    }

    void LaunchBall()
    {
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), 1f).normalized;
        rb.linearVelocity = direction * speed;
    }

    private void OnDestroy()
    {
        // Avisamos al GameManager cuando esta bola desaparece
        if (GameManager.Instance != null)
        {
            GameManager.Instance.BallDestroyed();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //COLISIÓN CON LA PALA
        if (collision.gameObject.CompareTag("Paddle"))
        {
            float paddleX = collision.transform.position.x;
            float hitX = transform.position.x;
            float paddleWidth = collision.collider.bounds.size.x;

            float offset = (hitX - paddleX) / (paddleWidth / 2f);

            Vector2 currentDir = rb.linearVelocity.normalized;
            Vector2 paddleDir = new Vector2(offset, 1f).normalized;

            // Influencia de la pala sobre la trayectoria de la bola para que sea un movimiento natural 
            float influence = 0.6f;

            Vector2 finalDir = Vector2.Lerp(currentDir, paddleDir, influence).normalized;
            rb.linearVelocity = finalDir * speed;

            return;
        }

        //COLISIÓN CON LADRILLOS 

        if (collision.gameObject.CompareTag("Brick"))
        {
            Brick brick = collision.gameObject.GetComponent<Brick>();
            if (brick != null)
            {
                GameManager.Instance.AddScore(brick.pointValue);
            }

            Destroy(collision.gameObject);
        }
    }
}
