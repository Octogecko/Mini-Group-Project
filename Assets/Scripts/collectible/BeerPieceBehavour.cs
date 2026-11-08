using UnityEngine;

public class BeerPieceBehavour : MonoBehaviour
{
    public bool IsSecondPiece;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            FindAnyObjectByType<PlayerPowerUp>().BeerPieces++;
            Destroy(gameObject);
        }
    }
}
