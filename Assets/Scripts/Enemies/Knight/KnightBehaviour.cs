using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.AI;

public class KnightBehaviour : MonoBehaviour
{
    public float speed = 2f;
    public PlayerInventory playerInventory; // need to put the coresponding script in the player
    public bool triggered = false;
    public bool stunned = false;
    public Transform leftPoint; 
    public Transform rightPoint; 
    private Transform currentTarget;

    void Start()
    {
        currentTarget = rightPoint;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && (!playerInventory.HammerInInventory))
        {
            stunned = true;
            GetComponent<Animator>().SetTrigger("Stunned");
        }
        else if (collision.gameObject.CompareTag("Player") && (!playerInventory.HammerInInventory))
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


