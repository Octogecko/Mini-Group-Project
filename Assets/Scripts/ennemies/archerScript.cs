using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private int directionStart = 1;
    [SerializeField] private int currentDirection;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private float spriteMoitieLargeur;
    private Vector2 movement;
  
    void Start()
    {
        currentDirection = -directionStart;
        spriteMoitieLargeur = spriteRenderer.bounds.extents.x; // On prend la moitié de la largeur du sprite
    }

    void FixedUpdate()
    {
        movement.x = speed * currentDirection;
        movement.y = rigidbody.linearVelocity.y;
        rigidbody.linearVelocity = movement;

        
    }
}
