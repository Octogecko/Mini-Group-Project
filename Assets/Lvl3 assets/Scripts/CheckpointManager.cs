using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    public Vector2 checkpointPosition;

    private void Awake()
    {
        Instance = this;
    }

    public void SetCheckpoint(Vector2 position)
    {
        checkpointPosition = position;

        Debug.Log("New checkpoint position: " + checkpointPosition);
    }

    public void Respawn(GameObject player)
    {
        player.transform.position = checkpointPosition;
    }
}