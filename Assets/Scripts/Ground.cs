using UnityEngine;

/// <summary>Class <c>Ground</c> models the main scene ground</summary>
public class Ground : MonoBehaviour
{
    private float movementX;

    private void FixedUpdate() {
        MoveGround();
    }

    /// <summary>Translate the ground sprite to the left until a specific x coordinate, 
    /// then move it to the starting point again</summary>
    private void MoveGround() {
        Vector2 newPos = new Vector2(Utils.GROUND_RIGHT_LIMIT, Utils.GROUND_Y);
        if (transform.position.x <= Utils.GROUND_LEFT_LIMIT) {
            transform.position = newPos;
        }
        movementX = Input.GetAxisRaw("Horizontal");
        Vector2 direction = new Vector2(movementX - 1.0f, 0);
        transform.Translate(direction * Utils.GROUND_SPEED * Time.deltaTime);
    }
}
