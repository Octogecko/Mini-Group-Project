using Unity.VisualScripting;
using UnityEngine;

public class BreakableBarrelBehavour : MonoBehaviour
{

    [SerializeField] private GameObject Contain;

    [SerializeField] private int Strength;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            FindAnyObjectByType<PlayerMovement>().GetComponent<Rigidbody2D>().linearVelocity = new Vector3(0, Strength,0);
            Instantiate(Contain, transform.position + new Vector3(0,1.5f,0), transform.rotation);
            GetComponent<Animator>().SetTrigger("Destroy");
            foreach(Collider2D i in GetComponents<Collider2D>())
            {
                i.enabled = false;
            }
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
