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

        [SerializeField] private float coyoteTime = 0.1f;
        [SerializeField] private float jumpForce = 17.5f;
        [SerializeField] private float jumpBuffer = 0.1f;
        [SerializeField] private float upGravity = 1f;
        [SerializeField] private float downGravity = 3.5f;
        public LayerMask groundLayers;  // Ernestin => J'ai modifié ça en public

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
        private bool jumpHeld = false;
        private bool isJumping = false;
        private bool isGrounded = false;
        private float timeNotGrounded = 0f;
        private float timeSinceJumpInput = 0f;

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
            if (timeNotGrounded > 0f)
            {
                timeNotGrounded += Time.deltaTime;
                if (timeNotGrounded >= coyoteTime)
                {
                    timeNotGrounded = 0f;
                    isGrounded = false;
                    if (!isJumping) StartFalling();
                }
            }
            if (timeSinceJumpInput > 0f)
            {
                timeSinceJumpInput += Time.deltaTime;
                if (timeSinceJumpInput >= jumpBuffer)
                {
                    timeSinceJumpInput = 0f;
                    jump = false;
                }
            }
        }

        private void FixedUpdate()
        {
            if (!GetComponent<HammerSkill>().Usinghammer)
            {
                transform.Translate(new Vector3(movement, 0).normalized * speed * Time.fixedDeltaTime);
            }

            if (jump && isGrounded)
            {
                timeNotGrounded = 0f;
                timeSinceJumpInput = 0f;
                rigidBody.linearVelocityY = 0f;
                rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isGrounded = false;
                isJumping = true;
                animator.SetBool("jumping", true);
                jump = false;
                CancelInvoke("StartFalling");
                if (!jumpHeld) StartFalling();
                else Invoke("StartFalling", 0.4f);
            }
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            if (!GetComponent<HammerSkill>().Usinghammer)  // Ernestin => J'ai ajouté ça
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
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                jump = true;
                jumpHeld = true;
                timeSinceJumpInput = 0.0001f;
            }
            if (context.canceled && !isGrounded)
            {
                jumpHeld = false;
                if (isJumping)
                {
                    CancelInvoke("StartFalling");
                    StartFalling();
                }
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
            RaycastHit2D left = Physics2D.Raycast(new Vector3(transform.position.x - 0.4f, transform.position.y), Vector2.down, 0.6f, groundLayers);
            RaycastHit2D right = Physics2D.Raycast(new Vector3(transform.position.x + 0.4f, transform.position.y), Vector2.down, 0.6f, groundLayers);
            if (left || right)
            {
                if (GetComponent<HammerSkill>().Usinghammer) // Ernestin => J'ai ajouté ça
                {   
                    GetComponent<HammerSkill>().Usinghammer = false;
                    rigidBody.gravityScale = upGravity;
                }
                isGrounded = true;
                timeNotGrounded = 0f;
                animator.SetBool("jumping", false);
                rigidBody.gravityScale = upGravity;
            }
            else
            {
                if (isGrounded && timeNotGrounded == 0f) timeNotGrounded = 0.0001f;
                animator.SetBool("jumping", true);
            }
        }

        private void StartFalling()
        {
            isJumping = false;
            rigidBody.gravityScale = downGravity;
        }
    }
