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
            FindAnyObjectByType<PlayerMovement>().GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Strength));
            Instantiate(Contain, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
