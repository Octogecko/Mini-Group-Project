using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Rendering.Universal.ShaderGUI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int maxLife = 3;
    public float invincibilityDuration = 1.0f;
    public float flashInterval = 0.1f;
    private int _life;
    bool isGameover = false;
    private Rigidbody2D rb;
    public ForceMode forceMode = ForceMode.Impulse;
    bool reload = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _life = maxLife;
        Scene currentScene = SceneManager.GetActiveScene();
    }
    void Update()
    {
        if (reload == true)
        {
            SceneManager.LoadScene(1);
        }
        if (isGameover == true)
        {
            GetComponent<PlayerMovement>().enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isGameover = true;
            GetComponent<Animator>().SetBool("ded", true);
            StartCoroutine(GameOverSequence());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Void"))
        {
            isGameover = true;
            GetComponent<Animator>().SetBool("hurt", true);
            StartCoroutine(GameOverSequence());
        }
    }
    private IEnumerator GameOverSequence()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void Hurt(int damage)
    {
        _life -= damage;
    }
}

