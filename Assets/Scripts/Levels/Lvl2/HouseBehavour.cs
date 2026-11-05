using System;
using UnityEngine;

public class HouseBehavour : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMovement>())
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

}
