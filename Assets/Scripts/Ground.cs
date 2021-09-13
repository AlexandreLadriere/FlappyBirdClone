using UnityEngine;

public class Ground : MonoBehaviour
{
    private float speed = 2.5f;
    private float movementX;
    private float RIGHT_LIMIT = 2.87f;
    private float LEFT_LIMIT = -2.87f;
    private float GROUND_Y = -4.16f;

    private void FixedUpdate() {
        MoveGround();
    }

    private void MoveGround() {
        Vector2 newPos = new Vector2(RIGHT_LIMIT, GROUND_Y);
        if (transform.position.x <= LEFT_LIMIT) {
            transform.position = newPos;
        }
        movementX = Input.GetAxisRaw("Horizontal");
        Vector2 direction = new Vector2(movementX - 1.0f, 0);
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
