using UnityEngine;

public class TransitionCastle : MonoBehaviour
{
    [Header("CastleDoor")]
    public Collider2D doorEnter;
    public Collider2D doorExit;
    public GameObject castle;
    bool hesInside = false;
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
        if (collision.gameObject.tag == "Player" && hesInside == false)
        {
            castle.SetActive(false);
            hesInside = true;
        }
    }
}
