using UnityEngine;

public class ToxicShroomBehavior : MonoBehaviour
{
    [Header("Mushroom Sprites")]
    public SpriteRenderer mushroomRenderer;
    public Sprite normalSprite;
    public Sprite activatedSprite;

    [Header("Toxic Effect")]
    public GameObject toxicEffect;
    public Animator toxicAnimator;

    private bool activated = false;

    private void Start()
    {
        mushroomRenderer.sprite = normalSprite;
        toxicEffect.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated) return;

        if (other.CompareTag("Player"))
        {
            activated = true;

            mushroomRenderer.sprite = activatedSprite;

            toxicEffect.SetActive(true);

            toxicAnimator.SetTrigger("Spread");
        }
    }

    public void ToxicAnimationFinished()
    {
        toxicEffect.SetActive(false);

        mushroomRenderer.sprite = normalSprite;

        activated = false;
    }
}
