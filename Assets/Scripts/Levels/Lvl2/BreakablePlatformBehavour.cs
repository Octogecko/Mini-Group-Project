using System.Collections;
using UnityEngine;

public class BreakablePlatformBehavour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            StartCoroutine(Break());
        }
    }

    IEnumerator Break()
    {
        GetComponent<Collider2D>().enabled = false;
        foreach (Transform t in transform)
        {
            t.GetComponent<Rigidbody2D>().simulated = true;
        }

        yield return new WaitForSeconds(3f);

        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
    }

}
