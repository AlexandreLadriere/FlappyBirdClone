using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private float movementX;

    private void FixedUpdate()
    {
        MoveObstacles();
    }

    private void MoveObstacles()
    {
        Vector2 newPos = new Vector2(0f, Random.Range(Utils.OBSTACLES_LOWER_LIMIT, Utils.OBSTACLES_UPPER_LIMIT));
        if (transform.position.x < Utils.OBSTACLES_OFF_SCREEN_LIMIT)
        {
            transform.position = newPos;
        }
        movementX = Input.GetAxisRaw("Horizontal");
        Vector2 direction = new Vector2(movementX - 1.0f, 0);
        transform.Translate(direction * Utils.OBSTACLES_SPEED * Time.deltaTime);
    }
}
