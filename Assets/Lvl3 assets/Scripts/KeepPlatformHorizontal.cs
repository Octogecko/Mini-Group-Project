using UnityEngine;

public class KeepPlatformHorizontal : MonoBehaviour
{
    private float initialAngle;

    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, initialAngle);
    }

    void Start()
    {
        initialAngle = transform.eulerAngles.z;
    }
}