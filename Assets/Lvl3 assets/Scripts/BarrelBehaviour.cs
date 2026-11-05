using System.Collections;
using UnityEngine;

public class BarrelBehaviour : MonoBehaviour
{
    [Header("Barrel")]
    public Collider2D barrelCollider;
    public SpriteRenderer barrelRenderer;
    public Rigidbody2D barrelRb;

    [Header("Explosion")]
    public GameObject explosion;
    public Animator explosionAnimator;

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

        explosion.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (destroyed) return;

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.layer == LayerMask.NameToLayer("BarrelCancel"))
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

        explosionAnimator.Play("Explosion", 0, 0f);

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
        barrelRb.linearVelocity = Vector2.zero;
        barrelRb.angularVelocity = 0f;

        barrelRenderer.enabled = true;
        barrelCollider.enabled = true;

        destroyed = false;
    }
}