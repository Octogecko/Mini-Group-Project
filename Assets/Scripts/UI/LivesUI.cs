using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LivesUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int lives;
    public Sprite[] chiffres;
    public Image[] emplacements;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lives = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>()._life;
        AfficherLives();
    }

    public void AfficherLives()
    {
        string scoreTexte = lives.ToString("D1");

        for (int i = 0; i < emplacements.Length; i++)
        {
            int chiffre = int.Parse(scoreTexte[i].ToString());

            emplacements[i].sprite = chiffres[chiffre];
        }
    }
}
