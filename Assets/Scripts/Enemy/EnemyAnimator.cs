
using UnityEngine;

//
// Pachinko Vaders v2025.07.04
//
// v2025.08.20
//

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
        StartUp();
    }


    private void StartUp()
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
