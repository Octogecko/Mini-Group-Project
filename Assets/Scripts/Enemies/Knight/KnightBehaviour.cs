using UnityEngine;

public class KnightBehaviour : MonoBehaviour
{
    public float speed = 2f;
    public PlayerInventory playerInventory; // need to put the coresponding script in the player
    public bool triggered = false;
    public bool stunned = false;
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && (!playerInventory.HammerInInventory))
        {
            stunned = true;
            GetComponent<Animator>().SetTrigger("Stunned");
        }
        else if (collision.gameObject.CompareTag("Player") && (!playerInventory.HammerInInventory))
        {
            Destroy(gameObject, 2f);
        }
    }
    void Update()
    {
        transform.position = new Vector3(speed * Time.deltaTime, 0);

    }
}


