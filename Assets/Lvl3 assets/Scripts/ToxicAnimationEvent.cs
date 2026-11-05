using UnityEngine;

public class ToxicAnimationEvent : MonoBehaviour
{
    public ToxicShroomBehavior mushroom;

    public void ToxicAnimationFinished()
    {
        mushroom.ToxicAnimationFinished();
    }
}