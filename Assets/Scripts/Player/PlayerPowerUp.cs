using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerPowerUp : MonoBehaviour
{

    public Sprite[] beerSteps;
    public Image emplacement;
    public int BeerPieces;
    public bool Full;

    public void Start()
    {
        Full = false;
        BeerPieces = 0;
    }

    void Update()
    {
        if (BeerPieces == 0)
        {
            emplacement.sprite = beerSteps[0];
        }
        else if (BeerPieces == 1)
        {
            emplacement.sprite = beerSteps[1];
        }
        else if (BeerPieces == 2 && Full != true)
        {
            emplacement.sprite = beerSteps[2];
            Invoke("finishedBeer", 2f);
        }
    }

    public void finishedBeer()
    {
        emplacement.sprite = beerSteps[3];
        Full = true;
    }
}
