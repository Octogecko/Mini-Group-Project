using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 5f;

    private int movement;
    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        float input = context.ReadValue<float>();

        
        if (input > 0)
        {
            movement = 1;
        }
        else if (input < 0)
        {
            movement = -1;
        }
        else
        {
            movement = 0;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, -0.3f);
        if (context.started && hit )
        {
            rigidBody.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(transform.position + new Vector3(movement, 0, 0) * speed * Time.deltaTime);
    }
}
