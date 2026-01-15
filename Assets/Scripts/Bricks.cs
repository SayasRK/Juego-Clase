using UnityEngine;

public class Brick : MonoBehaviour
{
    public int pointValue = 1;
    public GameObject powerUpPrefab;

    private void OnDestroy()
    {
        if (GameManager.Instance == null) return;

        GameManager.Instance.BrickDestroyed(pointValue);
        TryDropPowerUp();
    }

    void TryDropPowerUp()
    {
        float dropChance = 0.1f; // 10% de probabilidad

        if (powerUpPrefab != null && Random.value < dropChance)
        {
            Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
        }
    }
}
