using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimesUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int temps = 400;
    public Sprite[] chiffres;
    public Image[] emplacements;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Decompte());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Decompte()
    {
        if (temps > 0)
        {
            AfficherTemps();

            yield return new WaitForSeconds(1f);

            temps--;

            StartCoroutine(Decompte());
        }
        else
        {
        AfficherTemps();
        }

    }
    public void AfficherTemps()
    {
        string texte = temps.ToString("D3");

        for (int i = 0; i < emplacements.Length; i++)
        {
            Debug.Log(texte);
            int chiffre = int.Parse(texte[i].ToString());

            emplacements[i].sprite = chiffres[chiffre];
        }
    }
}
