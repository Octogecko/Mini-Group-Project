using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Transform currentPoint;
    private Rigidbody2D rb;
    public float speed = 2f;    

    void Start()
    {
        currentPoint = pointA.transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
           Vector2 point = currentPoint.position - transform.position;
            if (currentPoint == pointA.transform)
            {
                rb.linearVelocity = new Vector2(-speed, 0);
            }
            else
            {
                rb.linearVelocity = new Vector2(speed, 0);
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
            {
                currentPoint = pointB.transform;
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
            {
                currentPoint = pointA.transform;
            }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
    
        
}
