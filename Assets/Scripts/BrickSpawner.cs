using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brickPrefab;
    public int rows = 6;
    public int columns = 10;
    public float spacing = 0.2f;
    public Vector2 startPos = new Vector2(-7.5f, 4f);

    void Start()
    {
        SpawnBricks();
    }

    void SpawnBricks()  
    {
        Vector2 brickSize = brickPrefab.GetComponent<SpriteRenderer>().bounds.size;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector2 position = startPos + new Vector2(
                    col * (brickSize.x + spacing),
                    -row * (brickSize.y + spacing)
                );

                GameObject brick = Instantiate(brickPrefab, position, Quaternion.identity);

                
                SpriteRenderer sr = brick.GetComponent<SpriteRenderer>();
                sr.color = GetColorByRow(row);

                Brick brickScript = brick.GetComponent<Brick>();
                brickScript.pointValue = rows - row;

                GameManager.Instance.RegisterBrick();

            }
        }
    }

    Color GetColorByRow(int row)
    {
        switch (row)
        {
            case 0: return Color.red;
            case 1: return new Color(1f, 0.5f, 0f); 
            case 2: return Color.yellow;
            case 3: return Color.green;
            case 4: return Color.cyan;
            case 5: return Color.magenta;
            default: return Color.white;
        }
    }
}
