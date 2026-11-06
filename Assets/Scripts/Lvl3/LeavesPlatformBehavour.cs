using UnityEngine;

public class LeavesPlatformBehavour : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            GetComponents<BoxCollider2D>()[0].enabled = false;
            GetComponents<BoxCollider2D>()[1].enabled = false;
            GetComponent<Animator>().SetTrigger("Break");
        }
    }

    public void Break()
    {
        Destroy(gameObject);
    }
}
