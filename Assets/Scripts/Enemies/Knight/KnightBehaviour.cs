
using UnityEngine;
using UnityEngine.AI;

public class KnightBehaviour : MonoBehaviour
{
    public float speed = 2f;
    public Transform leftPoint; 
    public Transform rightPoint; 
    private Transform currentTarget;

    void Start()
    {
        currentTarget = rightPoint;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            Destroy(gameObject, 2f);
        }
    }
    void Update()
    {
        // Main code for pathfinding
        transform.position = Vector2.MoveTowards(transform.position,currentTarget.position,speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            currentTarget = (currentTarget == leftPoint) ? rightPoint : leftPoint;
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        }
    }
}


