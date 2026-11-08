using System.Collections;
using UnityEngine;

public class LockCamera : MonoBehaviour
{
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private bool lockY;
    [SerializeField] private float delay;
    public float yOffset;

    private void Start()
    {
        cameraMovement = FindAnyObjectByType<CameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(AddDelay());
        }
    }
    private IEnumerator AddDelay()
    {
        yield return new WaitForSeconds(delay);
        cameraMovement.yOffset = yOffset;
        if (lockY) cameraMovement.LockY();
        else cameraMovement.UnlockY();
    }
}
