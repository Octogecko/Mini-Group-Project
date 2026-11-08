using UnityEngine;

public class BeerRiverBehavour : MonoBehaviour
{

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerPowerUp>() && collision.gameObject.GetComponent<PlayerPowerUp>().Full == false && collision.gameObject.GetComponent<PlayerPowerUp>().BeerPieces >= 2)
        {
            collision.gameObject.GetComponent<PlayerPowerUp>().Full = true;
        }
    }
}
