using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float velocity = 4f;
    public bool isDead;
    public delegate void PlayerDied();
    public static event PlayerDied playerDiedInfo;

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
        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            rb.velocity = Vector2.up * velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        isDead = true;
        ExecuteEvent();
    }

    void ExecuteEvent() {
        if (playerDiedInfo != null) {
            playerDiedInfo();
        }
    }
}
