using UnityEngine;

public class enemyScriptMovement : MonoBehaviour
{
    public GameObject pointL;
    public GameObject pointR;
    public GameObject player;
    private Transform currentPoint;
    private Rigidbody2D rb;
    private bool isDead;

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
        if (isDead) return;

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
        else if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointR.transform)
        {
            currentPoint = pointL.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead || !collision.gameObject.CompareTag("Player")) return;

        Debug.Log(GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().GetScore());

        // La normale du contact pointe vers le bas quand le joueur tombe sur l'ennemi
        bool stomped = collision.GetContact(0).normal.y < -0.5f;
        Debug.Log(stomped);

        if (stomped && gameObject.tag == "Infanteryman" && gameObject.GetComponent<PlayerPowerUp>().Full)
        {
            Die(300);
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 8f);
        }
        else if (stomped && gameObject.tag == "Enemy")
        {
            Die(100);
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 8f);
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

    private void Die(int points)
    {
        isDead = true;
        rb.linearVelocity = Vector2.zero;
        rb.simulated = false; // plus de collisions ni de physique pendant l'animation de mort
        GetComponent<Animator>().SetTrigger("death");
        GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().AddScore(points);
        Invoke("destroying", 2f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(pointL.transform.position, 0.5f);
        Gizmos.DrawSphere(pointR.transform.position, 0.5f);
        Gizmos.DrawLine(pointL.transform.position, pointR.transform.position);
    }

    public void destroying()
    {
        Destroy(gameObject);
    }
}