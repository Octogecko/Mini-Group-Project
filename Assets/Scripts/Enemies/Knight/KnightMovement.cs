using UnityEngine;

public class KnightMovement : MonoBehaviour
{
    public float speed = 2f;
    public bool triggered = false;
    public bool stunned = false;
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && 
        {
            
        }
    }
    void Update()
    {
        
    }
}
