using UnityEngine;

public class Brick : MonoBehaviour
{
    public int pointValue = 1;
    public GameObject[] powerUpPrefabs;

    public void OnHit()
    {
        GameManager.Instance.BrickDestroyed(pointValue);
        TryDropPowerUp();
        Destroy(gameObject);
    }

    void TryDropPowerUp()
    {
        float dropChance = 0.1f;

        if (powerUpPrefabs == null || powerUpPrefabs.Length == 0) return;

        if (Random.value < dropChance)
        {
            int index = Random.Range(0, powerUpPrefabs.Length);
            Instantiate(powerUpPrefabs[index], transform.position, Quaternion.identity);
        }
    }
}
