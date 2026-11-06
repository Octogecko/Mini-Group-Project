using UnityEngine;

public class SpikeTraps : MonoBehaviour
{
    [Header("Spike Collision")]
    public Collider2D spikeCollider;
    [Header("KnockBack")]
    public float knockbackForce = 8f;
    public float upwardForce = 4f;
    [SerializeField] private int damage = 1;
    public void SpikesOut()
    {
        spikeCollider.enabled = true;
    }

    public void SpikesIn()
    {
        spikeCollider.enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerLife>().Hurt(damage);
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
