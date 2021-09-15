using UnityEngine;

/// <summary>Class <c>Obstacles</c> models the obstacles</summary>
public class Obstacles : MonoBehaviour
{
    private float movementX;

    private void FixedUpdate()
    {
        MoveObstacles();
    }

    /// <summary>Translate the obstacle sprite to the left until a specific x coordinate, 
    /// then move it to the starting point and setting the y coordinate to a random value</summary>
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
