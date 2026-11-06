using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float yOffset = 3f;
    [SerializeField] private float minX = 0f;
    [SerializeField] private float maxX = 1000f;
    [SerializeField] private bool yLocked = false;
    private Transform playerTransform;
    private Vector3 targetPosition = new Vector3();
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

        if (targetPosition.x < minX)
        {
            targetPosition.x = minX;
        }
        else if (targetPosition.x > maxX)
        {
            targetPosition.x = maxX;
        }
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
