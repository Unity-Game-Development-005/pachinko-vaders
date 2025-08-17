
using UnityEngine;


public class EnemyAnimator : MonoBehaviour
{
    public Sprite[] animationSprites;

    public float animationTime = 1f;

    private SpriteRenderer spriteRenderer;

    private int animationFrame;




    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), animationTime, animationTime);
    }


    private void AnimateSprite()
    {
        animationFrame++;

        if (animationFrame >= animationSprites.Length)
        {
            animationFrame = 0;
        }

        spriteRenderer.sprite = animationSprites[animationFrame];
    }


} // end of class
