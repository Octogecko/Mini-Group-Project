using UnityEngine;

public class SecretRoomCamera : MonoBehaviour
{

    [SerializeField] private Camera MainCam, SecretCam;
    private bool IsInSecretRoom;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            if (!IsInSecretRoom)
            {

                IsInSecretRoom = true;
                MainCam.enabled = false;
                SecretCam.enabled = true;
            }
            else
            {
                IsInSecretRoom = false;
                MainCam.enabled = true;
                SecretCam.enabled = false;
            }
        }
       
    }
}
