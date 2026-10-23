using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 moveInput;
    private float speedX, speedY;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

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

}
