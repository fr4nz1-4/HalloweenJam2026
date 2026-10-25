using System;
using System.Collections;
using UnityEngine;

public class fishingRod : MonoBehaviour
{
    public float animationSpeed;
    private SpriteRenderer spriteRenderer;
    private Collider2D collider;
    private GameObject fish;
    private bool collisionHappened = false;
    public GameManager gameManager;
    public AudioSource audioSource;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        fish = null;
    }

    private void Update()
    {
        if (collisionHappened && fish.transform.position.y <= 6)
        {
            fish.transform.position += new Vector3(0, animationSpeed * Time.deltaTime, 0);
            gameObject.transform.position += new Vector3(0, animationSpeed * Time.deltaTime, 0);
        }

        if (fish != null && fish.transform.position.y >= 6)
        {
            gameManager.youLoose();
            StartCoroutine(gameManager.sceneLink.waitAndChangeScene(5));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            audioSource.PlayOneShot(audioSource.clip);
            Debug.Log("A collider has entered the fishing rod trigger");
            fish = collision.gameObject;
            fish.GetComponent<playerController>().enabled = false;
            fish.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            collisionHappened = true;
        }
    }
}
