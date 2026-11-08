using System.Collections;
using UnityEngine;

public class BossAttackHitbox : MonoBehaviour
{
    public float knockbackForce = 8f;
    public float upwardForce = 5f;
    public float deathAnimationDuration = 1f;

    private bool playerHit = false;

    private void OnEnable()
    {
        playerHit = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !playerHit)
        {
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();

            if (playerRb != null)
            {
                playerHit = true;

                Vector2 direction =
                    (collision.transform.position - transform.parent.position).normalized;

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

        if (CheckpointManager.Instance != null)
        {
            CheckpointManager.Instance.Respawn(player);
        }

        playerHit = false;
    }
}