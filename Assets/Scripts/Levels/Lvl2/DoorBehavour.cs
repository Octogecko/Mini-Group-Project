using UnityEngine;

public class DoorBehavour : MonoBehaviour, BPI_Button
{
    public void Push()
    {
        transform.parent.GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Animator>().SetTrigger("OpenDoor");
    }

}
