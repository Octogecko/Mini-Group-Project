using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private int directionStart = 1;
    [SerializeField] private int currentDirection;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private LayerMask groundLayers;
    private float spriteMoitieLargeur;
    private Vector3 movement;
  
    void Start()
    {
        currentDirection = -directionStart;
        spriteMoitieLargeur = spriteRenderer.bounds.extents.x; // On prend la moitié de la largeur du sprite
    }

    void FixedUpdate()
    {
        movement.x = speed * currentDirection;
        movement.y = rigidbody.linearVelocity.y;
        rigidbody.AddForce(movement);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, -spriteMoitieLargeur - 0.1f, groundLayers);
        if (hit && rigidbody.linearVelocity.x > 0)
        {
            currentDirection *= -1;
        }
        Debug.DrawRay(transform.position, Vector2.left * (-spriteMoitieLargeur - 0.1f), Color.red);  
    }




}
