using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), 1).normalized;
        rb.linearVelocity = direction * speed; 
    }

    public void ResetBall()
    {
        rb.linearVelocity = Vector2.zero; // Detenemos la bola
        transform.position = Vector3.zero; // Puedes ajustar la posición si quieres
        LaunchBall(); // La relanzamos
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
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
