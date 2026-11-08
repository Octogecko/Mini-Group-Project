using System.Collections;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public GameObject player;

    public float speed = 5f;
    public float BossRange = 10f;
    public float attackRange = 1f;

    public float wakeUpDuration = 2.3f;
    public float attackDuration = 1.2f;
    public float attackCooldown = 0.5f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool wokenUp = false;
    private bool isAwake = false;
    private bool isAttacking = false;
    private bool dead = false;


    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (dead || player == null) return;

        float distance = Mathf.Abs(
            transform.position.x - player.transform.position.x
        );

        // Wake up
        if (!wokenUp && distance <= BossRange)
        {
            wokenUp = true;
            animator.SetBool("WakeUp", true);
            StartCoroutine(WakeUpBoss());
        }

        if (!isAwake || isAttacking) return;

        // Attack
        if (distance <= attackRange)
        {
            StartCoroutine(AttackBoss());
        }
        else
        {
            animator.SetBool("Attack", false);
            animator.SetBool("Walk", true);

            Vector3 targetPosition = new Vector3(
                player.transform.position.x,
                transform.position.y,
                transform.position.z
            );

            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                speed * Time.deltaTime
            );

            spriteRenderer.flipX =
                transform.position.x < player.transform.position.x;
        }
    }

    private IEnumerator WakeUpBoss()
    {
        yield return new WaitForSeconds(wakeUpDuration);

        animator.SetBool("WakeUp", false);
        isAwake = true;
    }

    private IEnumerator AttackBoss()
    {
        isAttacking = true;

        animator.SetBool("Walk", false);
        animator.SetBool("Attack", true);

        // Wait for attack animation
        yield return new WaitForSeconds(attackDuration);

        animator.SetBool("Attack", false);

        // Wait before allowing another attack
        yield return new WaitForSeconds(attackCooldown);

        isAttacking = false;
    }

    public void Die()
    {
        if (dead) return;

        dead = true;

        animator.SetBool("Walk", false);
        animator.SetBool("Attack", false);
        animator.SetBool("WakeUp", false);
        animator.SetBool("Death", true);

        StartCoroutine(AnimationEnded2());
    }

    private IEnumerator AnimationEnded2()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, BossRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}