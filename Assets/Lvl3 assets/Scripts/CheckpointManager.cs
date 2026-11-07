using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;
    public Vector3 lastCheckpointPosition;
    private void Awake()
    {
        Instance = this;
    }
    public void SetCheckpoint(Vector3 position)
    {
        lastCheckpointPosition = position;
    }
    public void Respawn(GameObject player)
    {
        player.transform.position = lastCheckpointPosition;
    }
}
