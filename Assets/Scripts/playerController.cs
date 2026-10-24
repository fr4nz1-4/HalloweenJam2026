using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class playerController : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 moveInput;
    private float speedX, speedY;
    private Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public int scoreValue;
    public GameManager GameManager;
    private Color originalColor;
    private Color hitColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // spriteRenderer = GetComponent<SpriteRenderer>();
        scoreValue = 0;
        scoreValue = 0;
        originalColor = spriteRenderer.color;
        ColorUtility.TryParseHtmlString("#AB5757", out hitColor);
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.flipX = rb.linearVelocityX < 0;
        
        
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        // speedX = Input.GetAxis("Horizontal") * moveSpeed;
        // speedY = Input.GetAxis("Vertical") * moveSpeed;
        // rb.linearVelocity = new Vector2(speedX, speedY) * moveInput;
        rb.linearVelocity = moveInput * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("specialFish"))
        {
            Debug.Log("you touched another fish");
            StartCoroutine(hit());
            scoreValue += other.gameObject.GetComponent<specialFish>().points;
            Debug.Log(gameObject.name + "lost points: " + other.gameObject.GetComponent<specialFish>().points);
        }
    }

    IEnumerator hit()
    {
        spriteRenderer.color = hitColor;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = originalColor;
    }
}
