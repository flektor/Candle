using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{ 
    [SerializeField] List<Sprite> sprites = new ();

    SpriteRenderer _spriteRenderer;

    int _currentIndex;
    float _timeToNextSprite;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
           
        _currentIndex = 0;
        if(sprites.Count > 0)
        {
            updateTimeToNextSprite();
            SetCurrentSprite(sprites[_currentIndex]);
        }
    }

    private void Update()
    { 
        if(_currentIndex == sprites.Count)
        { 
            SetCurrentSprite(sprites[_currentIndex]); 
            return;
        }

        _timeToNextSprite -= Time.deltaTime;

       if (_timeToNextSprite > 0)
        {
             return;
        }

        _currentIndex++;
        SetCurrentSprite(sprites[_currentIndex]); 
        updateTimeToNextSprite();          
    }
  
    void SetCurrentSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }

   void updateTimeToNextSprite()
    {
        _timeToNextSprite = 60 / sprites.Count + 1; 
    }


}
