using UnityEngine;

public class LockCamera : MonoBehaviour
{
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private bool lockY;
    public float yOffset;

    private void Start()
    {
        cameraMovement = FindAnyObjectByType<CameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cameraMovement.yOffset = yOffset;
            if (lockY) cameraMovement.LockY();
            else cameraMovement.UnlockY();
        }
    }
}
