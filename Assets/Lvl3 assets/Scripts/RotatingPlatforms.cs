using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [Header("Rotation")]
    public float rotationSpeed = 45f;

    void Update()
    {
        transform.Rotate(
            0f,
            0f,
            rotationSpeed * Time.deltaTime
        );
    }
}
