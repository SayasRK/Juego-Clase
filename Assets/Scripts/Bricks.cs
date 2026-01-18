using UnityEngine;

public class Brick : MonoBehaviour
{
    public int pointValue = 1;
    public GameObject[] powerUpPrefabs;

    private void OnDestroy()
    {
        // Si no estamos jugando, no hacemos nada
        if (!Application.isPlaying) return;
        if (GameManager.Instance == null) return;

        GameManager.Instance.BrickDestroyed(pointValue);
        TryDropPowerUp();
    }

    void TryDropPowerUp()
    {
        float dropChance = 0.1f; // 10%

        if (powerUpPrefabs == null || powerUpPrefabs.Length == 0) return;

        if (Random.value < dropChance)
        {
            int index = Random.Range(0, powerUpPrefabs.Length);
            Instantiate(powerUpPrefabs[index], transform.position, Quaternion.identity);
        }
    }
}
