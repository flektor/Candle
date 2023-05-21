using System.Collections;
using System.Linq;
using UnityEngine;

public class CharacterSpiteController : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    [SerializeField] Sprite ForwardSpriteIddle;
    [SerializeField] Sprite BackwardSpriteIddle;
    [SerializeField] Sprite RightSpriteIddle;
    [SerializeField] Sprite LeftSpriteIddle;
    [SerializeField] Sprite ForwardSpriteWalking1;
    [SerializeField] Sprite ForwardSpriteWalking2;
    [SerializeField] Sprite BackwardSpriteWalking1;
    [SerializeField] Sprite BackwardSpriteWalking2;
    [SerializeField] Sprite LeftSpriteWalking;
    [SerializeField] Sprite RightSpriteWalking;

    CharacterController.Direction _prevDirection;
    int _step = 0;
    readonly float _stepTime = .2f;
    float _timeToNextStep; 

    void Start()
    {
        var charachterController = GetComponent<CharacterController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _prevDirection = CharacterController.Direction.Right;

        charachterController.OnMove += SetCurrentSprite;
        charachterController.OnStopMoving += SetBackToIddle;

        SetCurrentSprite(CharacterController.Direction.Right);
    }
      
    void SetBackToIddle(CharacterController.Direction direction)
    {  
        switch (_prevDirection)
        {
            case CharacterController.Direction.Forward:
                IddleForward();
               return;                

            case CharacterController.Direction.Backward:
                IddleBackward();
                return;

            case CharacterController.Direction.Left:
            case CharacterController.Direction.BackwardLeft:
            case CharacterController.Direction.ForwardLeft:
                IddleLeft();
                return;

            case CharacterController.Direction.Right:
            case CharacterController.Direction.BackwardRight:
            case CharacterController.Direction.ForwardRight:
                IddleRight();
                return;
        }
    }

    void SetCurrentSprite(CharacterController.Direction direction)
    {
        switch (direction)
        {
            case CharacterController.Direction.Forward: 
                MoveForward();
                break;

            case CharacterController.Direction.Backward: 
                MoveBackward();
                break;

            case CharacterController.Direction.Left:
            case CharacterController.Direction.BackwardLeft:
            case CharacterController.Direction.ForwardLeft: 
                MoveLeft();
                break;

            case CharacterController.Direction.Right:
            case CharacterController.Direction.BackwardRight:
            case CharacterController.Direction.ForwardRight:
                MoveRight();
                break;
            default:
                return;
        }

    }

    void MoveRight()
    {
        _timeToNextStep -= Time.deltaTime;

        if (_prevDirection != CharacterController.Direction.Right)
        {
            _prevDirection = CharacterController.Direction.Right;
            _timeToNextStep = 0;
            _step = 0;
        }

        if (_timeToNextStep > 0)
        {
            return;
        }

        _timeToNextStep = _stepTime;
      
        if (_step % 2 == 0)
        {
            _spriteRenderer.sprite = RightSpriteIddle;
            _step++;
            return;
        }

        _spriteRenderer.sprite = RightSpriteWalking;
        _step++;
    }

    void MoveLeft()
    { 
        _timeToNextStep -= Time.deltaTime;

        if (_prevDirection != CharacterController.Direction.Left)
        {
            _prevDirection = CharacterController.Direction.Left;
            _timeToNextStep = 0;
            _step = 0;
        }

        if (_timeToNextStep > 0)
        {
            return;
        }

        _timeToNextStep = _stepTime;
 
        if (_step % 2 == 0)
        {
            _spriteRenderer.sprite = LeftSpriteIddle;
            _step++;
            return;
        }

        _spriteRenderer.sprite = LeftSpriteWalking;
        _step++;
    }

    void MoveForward()
    {
        _timeToNextStep -= Time.deltaTime;

        if (_prevDirection != CharacterController.Direction.Forward)
        {
            _prevDirection = CharacterController.Direction.Forward;
            _timeToNextStep = 0;
            _step = 0;
        }

        if (_timeToNextStep > 0)
        {
            return;
        }

        _timeToNextStep = _stepTime;
 
        if (_step % 2 == 0)
        {
            _spriteRenderer.sprite = ForwardSpriteWalking1;
            _step++;
            return;
        }

        _spriteRenderer.sprite = ForwardSpriteWalking2;
        _step++; 
    }

    void MoveBackward()
    {
        _timeToNextStep -= Time.deltaTime; 

        if (_prevDirection != CharacterController.Direction.Backward)
        {
            _prevDirection = CharacterController.Direction.Backward;
            _timeToNextStep = 0;
            _step = 0;
        }

        if (_timeToNextStep > 0)
        {
            return;
        }

        _timeToNextStep = _stepTime;
 
        if (_step % 2 == 0)
        {
            _spriteRenderer.sprite = BackwardSpriteWalking1;
            _step++;
            return;
        }

        _spriteRenderer.sprite = BackwardSpriteWalking2;
        _step++;
    }

    void IddleRight()
    {
        _spriteRenderer.sprite = RightSpriteIddle;
    }

    void IddleLeft()
    {
        _spriteRenderer.sprite = LeftSpriteIddle;
    }
    void IddleForward()
    {
        _spriteRenderer.sprite = ForwardSpriteIddle;
    }
    void IddleBackward()
    {
        _spriteRenderer.sprite = BackwardSpriteIddle;
    }

}
