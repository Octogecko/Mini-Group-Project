using Unity.VisualScripting;
using UnityEngine;

public class BreakAnim : MonoBehaviour
{
    void Start()
    {

    }


    void Update()
    {
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Animator>().SetTrigger("Break");
        }
    }
}
