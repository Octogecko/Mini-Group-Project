using UnityEngine;
using System.Collections;

public class SpikeTraps : MonoBehaviour
{
    [Header("Spike Collision")]
    public Collider2D spikeCollider;
    public Animator playerAnimator;

    [Header("KnockBack")]
    public float knockbackForce = 8f;
    public float upwardForce = 4f;

    [SerializeField] private int damage = 1;
    [SerializeField] private float deathAnimationDuration = 1f;

    private bool playerHit = false;

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
        if (collision.gameObject.CompareTag("Player") && !playerHit)
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (playerRb != null)
            {
                playerHit = true;

                collision.gameObject.GetComponent<PlayerLife>().Hurt(damage);

                Vector2 direction = (collision.transform.position - transform.position).normalized;

                direction.y = Mathf.Max(direction.y, 0.3f);

                playerRb.AddForce(
                    new Vector2(direction.x * knockbackForce, upwardForce),
                    ForceMode2D.Impulse
                );


                StartCoroutine(WaitForDeathAnimation(collision.gameObject));
            }
        }
    }

    private IEnumerator WaitForDeathAnimation(GameObject player)
    {
        yield return new WaitForSeconds(deathAnimationDuration);

        CheckpointManager.Instance.Respawn(player);

        playerHit = false;

    }
}