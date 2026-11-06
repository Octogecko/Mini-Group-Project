using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject pointL;
    public GameObject pointR;
    private Transform currentPoint;
    private Rigidbody2D rb;
    public float speed = 2f;
    [SerializeField] private int damage = 1;


    void Start()
    {
        currentPoint = pointL.transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
           Vector2 point = currentPoint.position - transform.position;
            if (currentPoint == pointL.transform)
            {
            GetComponent<SpriteRenderer>().flipX = false;
                rb.linearVelocity = new Vector2(-speed, 0); 
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true; 
                rb.linearVelocity = new Vector2(speed, 0);
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointL.transform)
            {
                currentPoint = pointR.transform;
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointR.transform)
            {
                currentPoint = pointL.transform;
            }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerLife>().Hurt(damage);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(pointL.transform.position, 0.5f);
        Gizmos.DrawSphere(pointR.transform.position, 0.5f);
        Gizmos.DrawLine(pointL.transform.position, pointR.transform.position);
    }
    
        
}
