using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    public Vector2 checkpointPosition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCheckpoint(Vector2 position)
    {
        checkpointPosition = position;

        Debug.Log("New checkpoint position: " + checkpointPosition);
    }

    public void Respawn(GameObject player)
    {
        Debug.Log("Respawning player at: " + checkpointPosition);

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }

        player.transform.position = checkpointPosition;
    }
}