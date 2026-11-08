using Unity.VisualScripting;
using UnityEngine;

public class ChenineyBehavour : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMovement>())
        {
            GetComponent<SpriteRenderer>().sortingOrder = -1;
            foreach (BoxCollider2D i in GetComponents<BoxCollider2D>())
            {
                i.enabled = false;
            }
            GetComponents<BoxCollider2D>()[3].enabled = true;


        }
    }

}
