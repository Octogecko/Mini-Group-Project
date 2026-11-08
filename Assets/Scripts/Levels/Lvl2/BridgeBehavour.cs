using UnityEngine;

public class BridgeBehavour : MonoBehaviour, BPI_Button
{
    public void Push()
    {
        GetComponent<Animator>().SetTrigger("OpenBridge");
    }

}
