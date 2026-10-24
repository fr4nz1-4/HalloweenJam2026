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
    private float defaultSpeed;
    private Color hitColor;
    private Color foodColor;
    private Color shockColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // spriteRenderer = GetComponent<SpriteRenderer>();
        scoreValue = 0;
        scoreValue = 0;
        originalColor = spriteRenderer.color;
        ColorUtility.TryParseHtmlString("#AB5757", out hitColor);
        ColorUtility.TryParseHtmlString("#39FF47", out foodColor);
        ColorUtility.TryParseHtmlString("#727272", out shockColor);
        defaultSpeed = moveSpeed;
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
            GameObject otherFish = other.gameObject;
            if (otherFish.GetComponent<specialFish>().points < 0)
            {
                StartCoroutine(hit(otherFish));
            } else if (otherFish.GetComponent<specialFish>().points > 0)
            {
                StartCoroutine(food(otherFish));
            }

            if (otherFish.GetComponent<specialFish>().speed < -2)
            {
                StartCoroutine(shock(otherFish));
            }
            
            scoreValue += otherFish.GetComponent<specialFish>().points;
            StartCoroutine(speed(otherFish));
            Debug.Log(gameObject.name + "lost points: " + other.gameObject.GetComponent<specialFish>().points);
        }
    }

    IEnumerator food(GameObject otherFish)
    {
        spriteRenderer.color = foodColor;
        yield return new WaitForSeconds(0.05f);
        otherFish.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalColor;
    }

    IEnumerator hit(GameObject otherFish)
    {
        spriteRenderer.color = hitColor;
        yield return new WaitForSeconds(0.05f);
        otherFish.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalColor;
    }

    IEnumerator speed(GameObject otherFish)
    {
        moveSpeed += otherFish.GetComponent<specialFish>().speed;
        yield return new WaitForSeconds(5f);
        moveSpeed = defaultSpeed;
    }

    IEnumerator shock(GameObject otherFish)
    {
        spriteRenderer.color = shockColor;
        yield return new WaitForSeconds(0.1f);
        otherFish.gameObject.SetActive(false);
        spriteRenderer.color = originalColor;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = shockColor;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalColor;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = shockColor;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalColor;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = shockColor;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalColor;
    }
}
