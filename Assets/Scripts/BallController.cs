using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 8f;
    public bool isExtraBall = false;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = isExtraBall ? Color.blue : Color.white;
        }

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
        //Colision de la pala

        if (collision.gameObject.CompareTag("Paddle"))
        {
            float paddleX = collision.transform.position.x;
            float hitX = transform.position.x;

            float paddleWidth = collision.collider.bounds.size.x;

            float offset = (hitX - paddleX) / (paddleWidth / 2f);

            Vector2 currentDir = rb.linearVelocity.normalized;
            Vector2 paddleDir = new Vector2(offset, 1f).normalized;

            float influence = 0.6f;
            //Cambiando esto conseguimos que el rebote sea mas o menos natural, mas o menos fuerte. 

            Vector2 finalDir = Vector2.Lerp(currentDir, paddleDir, influence).normalized;
            rb.linearVelocity = finalDir * speed;

            return;

            //Control del comportamiento de la bola y ajuste del rebote contra la pala
            //Para poder conseguir esa fluidez de la trayectoria de la bola 
        }

        // Colision del ladrillo 

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
