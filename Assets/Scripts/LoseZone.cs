using UnityEngine;

public class LoseZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si entra una bola, simplemente se destruye
        if (other.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
        }

        // Limpiamos power-ups que caigan fuera
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
    }
}
