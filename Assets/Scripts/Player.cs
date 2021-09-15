using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isDead;
    public delegate void PlayerDied();
    public static event PlayerDied playerDiedInfo;
    public delegate void Score();
    public static event Score score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        // go up if space or main key clicked
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * Utils.PLAYER_VELOCITY;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isDead = true;
        if (playerDiedInfo != null)
        {
            playerDiedInfo();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (score != null)
        {
            score();
        }
    }
}
