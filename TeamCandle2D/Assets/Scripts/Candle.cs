using System;
using System.Collections;
using UnityEngine;

public class Candle : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    SpriteRenderer spriteRenderer;
    int _currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Animate();
    }

    public void Animate()
    {
        StopCoroutine(nameof(SequenceStart));

        _currentIndex = 0;
        spriteRenderer.sprite = sprites[_currentIndex];
        StartCoroutine(nameof(SequenceStart));
    }

    IEnumerator SequenceStart()
    {
        var timeToNextSprite = +.3f + 60 / sprites.Length;

        for (_currentIndex = 0; _currentIndex < sprites.Length; _currentIndex++)
        { 
            yield return new WaitForSeconds(timeToNextSprite);
            spriteRenderer.sprite = sprites[_currentIndex];
        }
    }
}
