using UnityEngine;
using Direction = CharacterController.Direction;

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
     
    Direction _prevDirection;
    int _step = 0;
    readonly float _stepTime = .2f;
    float _timeToNextStep;

    void Start()
    {
        var charachterController = GetComponent<CharacterController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        charachterController.OnMove += SetCurrentSprite;
        charachterController.OnStopMoving += SetBackToIddle;
    }

    void SetBackToIddle(Direction direction)
    {
        _step = 0;
        _timeToNextStep = 0;

        switch (_prevDirection)
        {
            case Direction.Forward:
                _spriteRenderer.sprite = ForwardSpriteIddle;
                return;

            case Direction.Backward:
                _spriteRenderer.sprite = BackwardSpriteIddle;
                return;

            case Direction.Left:
            case Direction.BackwardLeft:
            case Direction.ForwardLeft:
                _spriteRenderer.sprite = LeftSpriteIddle;
                return;

            case Direction.Right:
            case Direction.BackwardRight:
            case Direction.ForwardRight:
                _spriteRenderer.sprite = RightSpriteIddle;
                return;
        }
    }

    void SetCurrentSprite(Direction direction)
    {
        switch (direction)
        {
            case Direction.Forward:
                Move(Direction.Forward, ForwardSpriteWalking1, ForwardSpriteWalking2);
                return;

            case Direction.Backward:
                Move(Direction.Backward, BackwardSpriteWalking1, BackwardSpriteWalking2);
                return;

            case Direction.Left:
            case Direction.BackwardLeft:
            case Direction.ForwardLeft:
                Move(Direction.Left, LeftSpriteWalking, LeftSpriteIddle);
                return;

            case Direction.Right:
            case Direction.BackwardRight:
            case Direction.ForwardRight:
                Move(Direction.Right, RightSpriteWalking, RightSpriteIddle);
                return;
        }
    } 


    void Move(Direction direction, Sprite sprite1, Sprite sprite2)
    {
        _timeToNextStep -= Time.deltaTime;

        if (_prevDirection != direction)
        {
            _prevDirection = direction;
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
            _spriteRenderer.sprite = sprite1;
            _step++;
            return;
        }

        _spriteRenderer.sprite = sprite2;
        _step++;
    }
}
