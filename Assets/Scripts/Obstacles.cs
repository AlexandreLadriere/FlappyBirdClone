using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private float speed = 2.5f;
    private float movementX;
    private float OFF_SCREEN_LIMIT = -9.0f;
    private float UPPER_LIMIT = 4.9f;
    private float LOWER_LIMIT = 0.6f;

    private void FixedUpdate()
    {
        MoveObstacles();
    }

    private void MoveObstacles()
    {
        Vector2 newPos = new Vector2(0f, Random.Range(LOWER_LIMIT, UPPER_LIMIT));
        if (transform.position.x < OFF_SCREEN_LIMIT)
        {
            transform.position = newPos;
        }
        movementX = Input.GetAxisRaw("Horizontal");
        Vector2 direction = new Vector2(movementX - 1.0f, 0);
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
