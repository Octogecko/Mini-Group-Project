using System.Collections;
using UnityEngine;

public class BarrelBehaviour : MonoBehaviour
{
    [Header("Barrel")]
    public Collider2D barrelCollider;
    public SpriteRenderer barrelRenderer;
    public Rigidbody2D barrelRb;
    public float barrelStrenghSpeed;

    [Header("Explosion")]
    public GameObject explosion;
    public Animator explosionAnimator;
    [Header("KnockBack")]
    public float knockbackForce = 8f;
    public float upwardForce = 4f;

    [Header("Respawn")]
    public float respawnDelay = 3f;
    [Header("Respawn Distance")]
    public Transform player;
    public float minRespawnDistance = 5f;

    private Vector3 originalPosition;
    private bool destroyed = false;

    void Start()
    {
        originalPosition = transform.position;
        barrelRb.linearVelocity = new Vector2(0f, -barrelStrenghSpeed);
        explosion.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (destroyed) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 direction = (collision.transform.position - transform.position).normalized;

            direction.y = Mathf.Max(direction.y, 0.3f);

            playerRb.AddForce(
                new Vector2(direction.x * knockbackForce, upwardForce),
                ForceMode2D.Impulse);

        destroyed = true;

            StartCoroutine(DestroyBarrel());
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Void"))
        {
            destroyed = true;

            StartCoroutine(DestroyBarrel());
        }
    }

    IEnumerator DestroyBarrel()
    {
        barrelRenderer.enabled = false;
        barrelCollider.enabled = false;

        barrelRb.linearVelocity = Vector2.zero;
        barrelRb.angularVelocity = 0f;
        barrelRb.bodyType = RigidbodyType2D.Kinematic;

        explosion.transform.position = transform.position;
        explosion.SetActive(true);


        yield return new WaitForSeconds(
            explosionAnimator.GetCurrentAnimatorStateInfo(0).length
        );

        explosion.SetActive(false);

        yield return new WaitForSeconds(respawnDelay);

        while (Vector2.Distance(player.position, originalPosition) < minRespawnDistance)
        {
            yield return null;
        }

        transform.position = originalPosition;

        barrelRb.bodyType = RigidbodyType2D.Dynamic;
        barrelRb.linearVelocity = new Vector2(0f, -barrelStrenghSpeed);
        barrelRb.angularVelocity = 1f;

        barrelRenderer.enabled = true;
        barrelCollider.enabled = true;

        destroyed = false;
    }
}