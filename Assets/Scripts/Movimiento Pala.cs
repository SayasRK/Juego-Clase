using UnityEngine;

public class MovimientoPala : MonoBehaviour
{
    public float moveSpeed = 10f;

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        // Movimiento en eje X global (izquierda/derecha)

        transform.position += new Vector3(move, 0, 0) * moveSpeed * Time.deltaTime;

        // Limitar dentro de la pantalla

        float xPos = Mathf.Clamp(transform.position.x, -7.5f, 7.5f);
        transform.position = new Vector2(xPos, transform.position.y);
    }
}

