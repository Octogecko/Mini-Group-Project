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
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {

            }
        }
    }
    

    public void Hurt(int damage)
    {
        _life -= damage;
        rb.AddForce(new Vector2(5, 0), ForceMode2D.Impulse);
    }


        //UpdateUI();
    }
    // Need to setup that when the Ui is ready
    //private void UpdateUI()
    //{
    //    lifeUI.fillAmount = (float)_life / maxLife;
    //}
