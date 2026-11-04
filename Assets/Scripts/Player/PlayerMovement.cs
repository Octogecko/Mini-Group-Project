using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Constants

    [SerializeField] private float baseSpeed = 0f;
    [SerializeField] private float maxSpeed = 7f;
    [SerializeField] private float accelerationSpeed = 14f;
    [SerializeField] private float decelerationSpeed = 15f;
    [SerializeField] private float runningMaxSpeed = 20f;
    [SerializeField] private float inAirAcceleration = 3f;

    [SerializeField] private float jumpForce = 17.5f;
    [SerializeField] private float upGravity = 1f;
    [SerializeField] private float downGravity = 3.5f;
    [SerializeField] private LayerMask groundLayers;

    // References

    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Movement

    [SerializeField] private float speed;
    private int movement;
    private int direction;
    private bool accelerating = false;
    private bool decelerating = false;
    private float decelerateTargetSpeed = 0f;
    private bool running = false;

    // Jump

    private bool jump = false;
    private bool isJumping = false;
    private bool isGrounded = false;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        speed = baseSpeed;
    }

    private void Update()
    {
        ChangeSpeed();
        if (speed == baseSpeed) movement = 0;

        CheckGround();
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(movement, 0).normalized * speed * Time.fixedDeltaTime);

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
            accelerating = true;
            direction = input > 0 ? 1 : -1;
            spriteRenderer.flipX = input < 0;
            animator.SetBool("walking", true);
        }
        else if (context.canceled)
        {
            decelerating = true;
            decelerateTargetSpeed = baseSpeed;
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
        if (context.started && isGrounded)
        {
            jump = true;
            isJumping = true;
            isGrounded = false;
            animator.SetBool("jumping", true);
            Invoke("StartFalling", 0.4f);
        }
        if (context.canceled && !isGrounded)
        {
            CancelInvoke("StartFalling");
            StartFalling();
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            running = true;
        }
        else if (context.canceled)
        {
            running = false;
            decelerating = true;
            decelerateTargetSpeed = maxSpeed;
        }
    }

    private void ChangeSpeed()
    {
        if (decelerating && speed > decelerateTargetSpeed)
        {
            if (speed - decelerationSpeed * Time.deltaTime < decelerateTargetSpeed)
            {
                speed = decelerateTargetSpeed;
                decelerating = false;
            }
            else
            {
                speed -= decelerationSpeed * Time.deltaTime;
            }
        }
        else if (accelerating && speed < (running ? runningMaxSpeed : maxSpeed))
        {
            movement = direction;
            if (speed + accelerationSpeed * Time.deltaTime > (running ? runningMaxSpeed : maxSpeed))
            {
                speed = (running ? runningMaxSpeed : maxSpeed);
            }
            else if (isGrounded)
            {
                speed += accelerationSpeed * Time.deltaTime;
            }
            else
            {
                speed += inAirAcceleration * Time.deltaTime;
            }
        }
        else if (movement == 0)
        {
            speed = baseSpeed;
        }
    }

    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, groundLayers);
        if (hit)
        {
            isGrounded = true;
            // isJumping = false; MARIE AIDE MOI
            animator.SetBool("jumping", false);
            rigidBody.gravityScale = upGravity;
        }
        else
        {
            isGrounded = false;
            animator.SetBool("jumping", true);
            if (!isJumping) rigidBody.gravityScale = downGravity;
        }
    }

    private void StartFalling()
    {
        rigidBody.gravityScale = downGravity;
    }
}
