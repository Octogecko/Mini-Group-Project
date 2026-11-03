using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float baseSpeed = 5f;
    [SerializeField] private float maxSpeed = 8f;
    [SerializeField] float accelerationSpeed = 8f;
    [SerializeField] float decelerationSpeed = 6f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float upGravity = 1f;
    [SerializeField] float downGravity = 4f;

    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private float speed;
    private int movement;
    private bool accelerating = false;
    private bool decelerating = false;
    private bool jump = false;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        speed = baseSpeed;
    }

    private void Update()
    {
        transform.position += new Vector3(movement, 0) * speed * Time.deltaTime;

        if (accelerating && speed < maxSpeed)
        {
            if (speed + accelerationSpeed * Time.deltaTime > maxSpeed)
            {
                speed = maxSpeed;
            }
            else
            {
                speed += accelerationSpeed * Time.deltaTime;
            }
        }
        else if (decelerating && speed > 0)
        {
            if (speed - decelerationSpeed * Time.deltaTime < 0)
            {
                speed = 0;
                decelerating = false;
                movement = 0;
            }
            else
            {
                speed -= decelerationSpeed * Time.deltaTime;
            }
        }
        else
        {
            speed = baseSpeed;
        }
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jump = false;
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        float input = context.ReadValue<float>();

        if (context.started)
        {
            if (!decelerating)
            {
                accelerating = true;
                movement = input > 0 ? 1 : -1;
            }
            spriteRenderer.flipX = input < 0;
            animator.SetBool("walking", true);
        }
        else if (context.canceled)
        {
            decelerating = true;
            accelerating = false;
            animator.SetBool("walking", false);
        }

        if (!decelerating && !accelerating && input != 0)
        {
            accelerating = true;
            movement = input > 0 ? 1 : -1;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, -0.3f);
        if (context.started && hit)
        {
            jump = true;
        }
    }
}
