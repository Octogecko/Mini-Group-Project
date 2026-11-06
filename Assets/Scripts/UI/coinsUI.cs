using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class coinsUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int coins;
    public Sprite[] chiffres;
    public Image[] emplacements;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AfficherScore();
    }

    public void AfficherScore()
    {
        string scoreTexte = coins.ToString("D3");

        for (int i = 0; i < emplacements.Length; i++)
        {
            int chiffre = int.Parse(scoreTexte[i].ToString());

            emplacements[i].sprite = chiffres[chiffre];
        }
    }
}
