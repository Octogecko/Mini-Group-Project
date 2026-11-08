using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject pointL;
    public GameObject pointR;
    public GameObject player;
    private Transform currentPoint;
    private Rigidbody2D rb;
    [Header("KnockBack")]
    public float knockbackForce = 8f;
    public float upwardForce = 4f;
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
            if (PlayerOnTop(player.transform, gameObject.transform))
            {
                GetComponent<Animator>().SetBool("nom de l'anim", true);
                GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().AddScore(100);
            }

            else
            {
                collision.gameObject.GetComponent<PlayerLife>().Hurt(damage);
                Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    Vector2 direction = (collision.transform.position - transform.position).normalized;
                    direction.y = Mathf.Max(direction.y, 0.3f);
                    playerRb.AddForce(new Vector2(direction.x * knockbackForce, upwardForce), ForceMode2D.Impulse);
                }
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(pointL.transform.position, 0.5f);
        Gizmos.DrawSphere(pointR.transform.position, 0.5f);
        Gizmos.DrawLine(pointL.transform.position, pointR.transform.position);
    }


    bool PlayerOnTop(Transform player, Transform infantryman)
    {
        return player.position.y > infantryman.position.y;
    }

}
