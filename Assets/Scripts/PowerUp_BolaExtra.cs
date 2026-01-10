using UnityEngine;

public class PowerUp_BolaExtra : MonoBehaviour
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
            SpawnExtraBall();
            Destroy(gameObject);
        }
    }

    void SpawnExtraBall()
    {
        Vector3 spawnPos = transform.position;
        GameObject newBall = Instantiate(ballPrefab, spawnPos, Quaternion.identity);
        newBall.tag = "BallExtra";

        Rigidbody2D rb = newBall.GetComponent<Rigidbody2D>();
        Vector2 dir = new Vector2(Random.Range(-1f, 1f), 1).normalized;
        rb.linearVelocity = dir * 8f;
    }
}
