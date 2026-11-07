using UnityEngine;

public class SpikeBehavour : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Collider2D>().enabled = false;
    }
}
