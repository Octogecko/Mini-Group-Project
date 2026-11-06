using UnityEngine;

public class BoucingShroom : MonoBehaviour
{
    [Header("KnockBack")]
    public float knockbackForce = 8f;
    public float upwardForce = 4f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (playerRb != null)
            {
                Vector2 direction = (collision.transform.position - transform.position).normalized;

                direction.y = Mathf.Max(direction.y, 0.3f);

                playerRb.AddForce(
                    new Vector2(direction.x * knockbackForce, upwardForce),
                    ForceMode2D.Impulse
                );
            }
        }
    }
}
