using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Candle : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] TimeKeeper timeKeeper;
    Image image;
    int _currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        timeKeeper.OnNewGame += OnNewGame;
        timeKeeper.OnDie += OnDie;
        image = GetComponent<Image>(); 
    } 

    void OnNewGame()
    { 
        Animate();
    }

    void OnDie()
    { 
        StopCoroutine(nameof(SequenceStart));
        image.sprite = sprites[sprites.Length-1];
    }

    public void Animate()
    {
        StopCoroutine(nameof(SequenceStart));

        _currentIndex = 0;
        image.sprite = sprites[_currentIndex];
        StartCoroutine(nameof(SequenceStart));
    }

    IEnumerator SequenceStart()
    {
        var timeToNextSprite = 60 / (sprites.Length - 1);

        for (_currentIndex = 1; _currentIndex < sprites.Length; _currentIndex++)
        {
            yield return new WaitForSeconds(timeToNextSprite);
            image.sprite = sprites[_currentIndex];
        }
    }
}
