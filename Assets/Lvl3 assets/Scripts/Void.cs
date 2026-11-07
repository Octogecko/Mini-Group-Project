using UnityEngine;

public class Void : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CheckpointManager.Instance.Respawn(collision.gameObject);
        }
    }
}
