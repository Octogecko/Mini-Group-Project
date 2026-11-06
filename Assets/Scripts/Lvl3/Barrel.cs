using UnityEngine;

public class Barrel : MonoBehaviour
{
    public float force = 2f;

    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(Vector2.left *  force, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= -20 )
        {
            Destroy(this);
        }
    }
}
