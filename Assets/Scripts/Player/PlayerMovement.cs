using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float upGravity = 1f;
    [SerializeField] float downGravity = 4f;

    private Rigidbody2D rigidBody;

    private int movement;
    private bool accelerating = false;
    private bool decelerating = false;
    private bool jump = false;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        float input = context.ReadValue<float>();

        
        if (input > 0)
        {
            accelerating = true;
            movement = 1;
        }
        else if (input < 0)
        {
            accelerating = true;
            movement = -1;
        }
        else
        {
            decelerating = true;
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

    private void Update()
    {
        transform.position += new Vector3(movement, 0) * speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jump = false;
        }
    }
}
