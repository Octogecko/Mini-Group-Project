using Unity.VisualScripting;
using UnityEngine;

public class coins : MonoBehaviour
{

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().coins++;
            Destroy(gameObject);
        }
    }
}
