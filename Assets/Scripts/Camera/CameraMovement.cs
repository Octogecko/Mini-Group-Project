using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float yOffset = 3f;
    private Transform playerTransform;
    private Vector3 targetPosition = new Vector3();
    private bool yLocked = false;
    private float targetY;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        LockY();
    }

    private void Update()
    {
        targetPosition = playerTransform.position;
        if (yLocked)
        {
            targetPosition.y = targetY;
        }
        targetPosition.y += yOffset;    
    }

    private void FixedUpdate()
    {
        transform.position = targetPosition;
    }

    public void LockY()
    {
        targetY = playerTransform.position.y;
        yLocked = true;
    }

    public void UnlockY()
    {
        yLocked = false;
    }
}
