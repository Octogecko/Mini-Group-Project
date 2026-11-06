using UnityEngine;

public class TransitionCastle : MonoBehaviour
{
    public bool passage = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (passage)
            {
                passage = false;
                GameObject.FindGameObjectWithTag("chateau").GetComponent<Animator>().SetTrigger("vanish");
            }
            else
            {
                passage = true;
                GameObject.FindGameObjectWithTag("chateau").GetComponent<Animator>().SetTrigger("vanish");
            }
        }
    }
}
