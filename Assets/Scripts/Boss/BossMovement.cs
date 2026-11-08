    using System.Collections;
    using UnityEngine;

    public class BossMovement : MonoBehaviour
    {
        public GameObject player;
        [Header("Attack Hitbox")]
        public GameObject attackHitbox;
        private Vector3 hitboxOriginalPosition;

        public float hitboxDuration = 0.3f;

        private bool facingRight = true;

        public float speed = 5f;
        public float BossRange = 10f;
        public float attackRange = 1f;

        public float wakeUpDuration = 2.3f;
        public float attackDuration = 1.2f;
        public float attackCooldown = 0.5f;
        public float attackDelay = 1f;

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
            attackHitbox.SetActive(false);
            hitboxOriginalPosition = attackHitbox.transform.localPosition;
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

            // Determine direction
            facingRight = transform.position.x < player.transform.position.x;
            spriteRenderer.flipX = facingRight;

            // Position hitbox in front of boss
            UpdateHitboxDirection();

            // Attack
            if (distance <= attackRange)
            {
                StartCoroutine(AttackBoss());
            }
            else
            {
                // Walk towards player
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

            yield return new WaitForSeconds(attackDelay);

            attackHitbox.SetActive(true);

            yield return new WaitForSeconds(hitboxDuration);

            attackHitbox.SetActive(false);

            float remainingTime = Mathf.Max(
                0f,
                attackDuration - attackDelay - hitboxDuration
            );

            yield return new WaitForSeconds(remainingTime);

            animator.SetBool("Attack", false);

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
    private void UpdateHitboxDirection()
    {
        if (spriteRenderer.flipX)
        {
            attackHitbox.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
        }
        else
        {
            attackHitbox.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, BossRange);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
    }