using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private float speedX, speedY;
    public float input;
    private SpriteRenderer spriteRenderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxis("Horizontal") * moveSpeed;
        speedY = Input.GetAxis("Vertical") * moveSpeed;
        rb.linearVelocity = new Vector2(speedX, speedY);

        spriteRenderer.flipX = rb.linearVelocityX < 0;
    }

    private void FixedUpdate()
    {
        // rb.linearVelocity = new Vector2(input * speed, playerRb.linearVelocity.y);
    }
}
