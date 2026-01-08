using UnityEngine;

public class LoseZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.Instance.LoseLife();
        }
    }
}

