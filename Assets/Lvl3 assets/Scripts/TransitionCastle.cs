using UnityEngine;

public class TransitionCastle : MonoBehaviour
{
    [Header("Castle")]
    public GameObject castleFG;

    [Header("Door Settings")]
    public bool isEntrance;

    private static bool IsInside = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        Debug.Log("Player entered trigger: " + gameObject.name);
        Debug.Log("IsInside: " + IsInside);
        Debug.Log("IsEntrance: " + isEntrance);

        if (isEntrance && !IsInside)
        {
            castleFG.SetActive(false);
            IsInside = true;
            Debug.Log("Entered castle!");
        }
        else if (!isEntrance && IsInside)
        {
            castleFG.SetActive(true);
            IsInside = false;
            Debug.Log("Exited castle!");
        }
    }
}