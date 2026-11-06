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
    private bool isInvincible = false;
    private int _life;
    bool isGameover = false;
    bool reloadScene = false;
    private Rigidbody2D rb;
    public ForceMode forceMode = ForceMode.Impulse;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _life = maxLife;
        Scene currentScene = SceneManager.GetActiveScene();
    }
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (_life <= 0)
            {
                isGameover = true;
                GetComponent<Animator>().SetBool("ded", true);
                StartCoroutine(GameOverSequence());
            }
            else
            {
                GetComponent<Animator>().SetBool("hurt", true);
            }
        }
        if (isGameover == true)
        {
            StartCoroutine(GameOverSequence());
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        GetComponent<Animator>().SetBool("hurt",false);
    }
    private IEnumerator GameOverSequence()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GetComponent<Animator>().SetBool("ded", false);
    }


    public void Hurt(int damage)
    {
        _life -= damage;
    }


        //UpdateUI();
    }
    // Need to setup that when the Ui is ready
    //private void UpdateUI()
    //{
    //    lifeUI.fillAmount = (float)_life / maxLife;
    //}
