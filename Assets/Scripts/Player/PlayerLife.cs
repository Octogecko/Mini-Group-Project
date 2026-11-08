using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int maxLife = 3;
    [SerializeField] public float invincibilityDuration = 1.0f;
    public float flashInterval = 0.1f;
    public int _life;

    private bool isGameover = false;
    private bool invincible = false;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        _life = maxLife;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Void"))
        {
            Die("hurt");
        }
    }

    public void Hurt(int damage)
    {
        if (invincible || isGameover) return;

        _life -= damage;

        if (_life <= 0)
        {
            Die("ded");
        }
        else
        {
            StartCoroutine(InvincibilityRoutine());
        }
    }

    private void Die(string animParam)
    {
        if (isGameover) return;
        isGameover = true;

        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<Animator>().SetBool(animParam, true);
        StartCoroutine(GameOverSequence());
    }

    private IEnumerator InvincibilityRoutine()
    {
        invincible = true;
        float elapsed = 0f;
        while (elapsed < invincibilityDuration)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(flashInterval);
            elapsed += flashInterval;
        }
        sr.enabled = true;
        invincible = false;
    }

    private IEnumerator GameOverSequence()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}