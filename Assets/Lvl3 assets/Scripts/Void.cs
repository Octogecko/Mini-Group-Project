using UnityEngine;

public class Void : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointManager.Instance.Respawn(other.gameObject);
        }
    }
}