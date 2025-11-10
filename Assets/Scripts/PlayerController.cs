using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float baseSpeed = 5f; // Base movement speed
    private float currentSpeed;

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    [Header("Size Ability Settings")]
    public Vector3 normalScale = new Vector3(1f, 1f, 1f);
    public Vector3 growScale = new Vector3(1.8f, 1.8f, 1.8f);
    public Vector3 shrinkScale = new Vector3(0.6f, 0.6f, 0.6f);
    public float scaleSpeed = 5f; // How smoothly the player changes size

    private Vector3 targetScale;

    [Header("Jump Settings")]
    public float jumpForce = 5f; // Jump power

    [Header("Fall Detection")]
    public float fallLimitY = -5f; // Y-level below which player loses

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Start at normal size and speed
        transform.localScale = normalScale;
        targetScale = normalScale;
        currentSpeed = baseSpeed * 1.6f; // Normal form starts fastest
        rb.mass = 1f;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        // Handle movement
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * currentSpeed);

        // Smoothly scale between sizes
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);
    }

    void Update()
    {
        // Jump anytime space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Lose if player falls off the platform
        if (transform.position.y < fallLimitY)
        {
            SceneManager.LoadScene("LoseScreen");
        }

        // Grow: strong but slightly slower
        if (Input.GetKeyDown(KeyCode.E))
        {
            targetScale = growScale;
            rb.mass = 2.0f;
            currentSpeed = baseSpeed * 1.3f; // slower than normal
            jumpForce = 6f;
        }

        // Shrink: light and fastest
        if (Input.GetKeyDown(KeyCode.Q))
        {
            targetScale = shrinkScale;
            rb.mass = 0.5f;
            currentSpeed = baseSpeed * 1.8f; // fastest
            jumpForce = 4f;
        }

        // Normal: fastest balanced mode
        if (Input.GetKeyDown(KeyCode.R))
        {
            targetScale = normalScale;
            rb.mass = 1f;
            currentSpeed = baseSpeed * 1.6f; // fast
            jumpForce = 5.5f;
        }
    }
}
