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
        GameObject newBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);

        // Marcar como bola extra (esto es lo importante)
        BallController bc = newBall.GetComponent<BallController>();
        if (bc != null)
        {
            bc.isExtraBall = true;
        }

        newBall.tag = "BallExtra";
    }
}

