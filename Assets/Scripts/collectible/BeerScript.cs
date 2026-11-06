using UnityEngine;

public class BeerScript : MonoBehaviour
{
    public GameObject player;
   
    void Start()
    {
       
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            player.GetComponent<Animator>().SetTrigger("BeerTake");
        }
    }
}
