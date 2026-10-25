using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class playerController : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 _moveInput;
    private float _speedX, _speedY;
    [FormerlySerializedAs("_rb")] public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public int scoreValue;
    public GameManager GameManager;
    private Color _originalColor;
    private float _defaultSpeed;
    private Color _hitColor, _foodColor, _shockColor;
    public AudioSource audioSource;
    public AudioClip[] biteSounds;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // spriteRenderer = GetComponent<SpriteRenderer>();
        scoreValue = 0;
        scoreValue = 0;
        _originalColor = spriteRenderer.color;
        ColorUtility.TryParseHtmlString("#AB5757", out _hitColor);
        ColorUtility.TryParseHtmlString("#39FF47", out _foodColor);
        ColorUtility.TryParseHtmlString("#727272", out _shockColor);
        _defaultSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.flipX = rb.linearVelocityX < 0;
    }

    void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = _moveInput * moveSpeed;
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
            
            StartCoroutine(speed(otherFish));
            scoreValue += otherFish.GetComponent<specialFish>().points;
            spriteRenderer.transform.localScale += new Vector3(0.005f, 0.005f, 0.005f) * otherFish.GetComponent<specialFish>().points;
            Debug.Log(gameObject.name + "lost points: " + other.gameObject.GetComponent<specialFish>().points);
        }
    }

    IEnumerator food(GameObject otherFish)
    {
        spriteRenderer.color = _foodColor;
        yield return new WaitForSeconds(0.05f);
        eatFish(otherFish);
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = _originalColor;
    }

    IEnumerator hit(GameObject otherFish)
    {
        spriteRenderer.color = _hitColor;
        yield return new WaitForSeconds(0.05f);
        eatFish(otherFish);
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = _originalColor;
    }

    IEnumerator speed(GameObject otherFish)
    {
        moveSpeed += otherFish.GetComponent<specialFish>().speed;
        yield return new WaitForSeconds(otherFish.GetComponent<specialFish>().duration);
        moveSpeed = _defaultSpeed;
    }

    IEnumerator shock(GameObject otherFish)
    {
        spriteRenderer.color = _shockColor;
        yield return new WaitForSeconds(0.1f);
        eatFish(otherFish);
        spriteRenderer.color = _originalColor;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = _shockColor;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = _originalColor;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = _shockColor;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = _originalColor;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = _shockColor;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = _originalColor;
    }

    void eatFish(GameObject fish)
    {
        int randomIndex = Random.Range(0, biteSounds.Length);
        audioSource.PlayOneShot(biteSounds[randomIndex]);
        fish.gameObject.SetActive(false);
    }
}
