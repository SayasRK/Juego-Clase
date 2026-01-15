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

            // Sumamos una vida al coger el power-up
            GameManager.Instance.AddLife(1);

            Destroy(gameObject);
        }
    }

    void SpawnExtraBall()
    {
        if (ballPrefab == null)
        {
            Debug.LogError("PowerUp_BolaExtra: ballPrefab NO asignado.");
            return;
        }

        // Spawn un poco por encima de la pala para que al cojer el power up la "bola extra" pueda salir
        Vector3 spawnPos = transform.position + Vector3.up * 0.6f;

        Instantiate(ballPrefab, spawnPos, Quaternion.identity);
    }
}
