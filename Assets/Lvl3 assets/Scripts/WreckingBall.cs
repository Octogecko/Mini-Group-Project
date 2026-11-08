using UnityEngine;

public class WreckingBall : MonoBehaviour
{
    [Header("Pendulum Settings")]
    public float swingAngle = 60f;
    public float speed = 2f;

    private Quaternion startRotation;

    void Start()
    {
        startRotation = transform.rotation;
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * speed) * swingAngle;

        transform.rotation =
            startRotation * Quaternion.Euler(0, 0, angle);
    }
}
