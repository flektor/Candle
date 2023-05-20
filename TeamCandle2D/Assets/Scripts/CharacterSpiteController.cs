using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CharacterSpiteController : MonoBehaviour
{ 
    SpriteRenderer _spriteRenderer ;
    public Sprite ForwardSprite;
    public Sprite BackwardSprite;
    public Sprite RightSprite;
    public Sprite LeftSprite;

    CharacterController.Direction _direction;

    // Start is called before the first frame update
    void Start()
    { 
        _spriteRenderer = GetComponent<SpriteRenderer>();
        var charachterController = GetComponent<CharacterController>();
        charachterController.OnChangeDirectionCallback = SetCurrentSprite;
        SetCurrentSprite(CharacterController.Direction.Right);
    }
     
    void SetCurrentSprite(CharacterController.Direction direction)
    {
        if(direction == CharacterController.Direction.Forward)
        {
            _spriteRenderer.sprite = ForwardSprite;
            return;
        }
        if (direction == CharacterController.Direction.Backward)
        {
            _spriteRenderer.sprite = BackwardSprite;
            return;
        }
        if (direction == CharacterController.Direction.Right)
        {
            _spriteRenderer.sprite = RightSprite;
            return;
        }
        if (direction == CharacterController.Direction.Left)
        {
            _spriteRenderer.sprite = LeftSprite;
            return;
        }

    }
 
 
}
