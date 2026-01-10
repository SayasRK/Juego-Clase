using UnityEngine;

public class LoseZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BallMain"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.LoseLife();
        }
        else if (other.CompareTag("BallExtra"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
    }
}
