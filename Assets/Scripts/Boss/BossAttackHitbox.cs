using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (!collision.CompareTag("Player") || playerHit)
            return;

        Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();

        if (playerRb == null)
        {
            Debug.LogError("Player has no Rigidbody2D!");
            return;
        }

        playerHit = true;

        Debug.Log("Player hit by boss!");

        Vector2 direction =
            (collision.transform.position - transform.parent.position).normalized;

        direction.y = Mathf.Max(direction.y, 0.3f);

        playerRb.linearVelocity = Vector2.zero;

        playerRb.AddForce(
            new Vector2(direction.x * knockbackForce, upwardForce),
            ForceMode2D.Impulse
        );
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}