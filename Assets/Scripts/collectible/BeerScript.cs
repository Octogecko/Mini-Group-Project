using UnityEngine;

public class BeerScript : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            GetComponent<SpriteRenderer>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("BeerTake");
        }
    }
}
