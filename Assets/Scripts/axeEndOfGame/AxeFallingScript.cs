using System.Collections;
using UnityEngine;

public class AxeFallingScript : MonoBehaviour
{
    private Animator animator;
    private Collider2D axeCollider;

    private bool hasFallen = false;

    public float resetDelay = 1f;

    void Start()
    {
        animator = GetComponent<Animator>();
        axeCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasFallen)
        {
            hasFallen = true;
            animator.SetTrigger("Fall");
        }
    }

    // Animation Event at the end of Fall animation
    public void AxeHasFallen()
    {
        bool bossHit = false;

        Collider2D[] hits = Physics2D.OverlapBoxAll(
            transform.position,
            axeCollider.bounds.size,
            0f
        );

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Boss"))
            {
                BossMovement boss = hit.GetComponent<BossMovement>();

                if (boss != null)
                {
                    boss.Die();
                    bossHit = true;
                }
            }
        }

        // If boss wasn't hit, reset axe
        if (!bossHit)
        {
            StartCoroutine(ResetAxe());
        }
    }

    private IEnumerator ResetAxe()
    {
        yield return new WaitForSeconds(resetDelay);

        animator.ResetTrigger("Fall");

        // Restart idle animation
        animator.Play("Idle", 0, 0f);

        hasFallen = false;
    }
}