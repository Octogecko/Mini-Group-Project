using UnityEngine;

public class TransitionCastle : MonoBehaviour
{
    [Header("Castle")]
    public GameObject castleFG;
    public Animator castleAnimator;

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
            castleAnimator.SetTrigger("CastleIn");
            IsInside = true;
            Debug.Log("Entered castle!");
        }
        else if (!isEntrance && IsInside)
        {
            castleAnimator.SetTrigger("CastleOut");
            IsInside = false;
            Debug.Log("Exited castle!");
        }
    }
}