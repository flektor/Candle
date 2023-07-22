using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField] StateManager state;

    Transform _transform;
    float _crossSpeed = .05f;
    float _diagonalSpeed = .05f * .7f;

    bool _prevKeyDown = false;
    Direction _prevDirection = Direction.Right;

    public OnMoveCallback OnMove;
    public delegate void OnMoveCallback(Direction direction);

    public OnStopMovingCallback OnStopMoving;
    public delegate void OnStopMovingCallback(Direction direction);

    Vector2 _initPosition;

    void Start()
    {
        _transform = GetComponent<Transform>();
        _prevDirection = Direction.Right;
        _initPosition = transform.position;

        state.OnNewGame += OnNewGame;
    }

    void OnNewGame()
    {
        transform.position = _initPosition; 
    }

    void FixedUpdate()
    {

        if(!state.IsPlaying)
        {
            return;
        }

        var forwardKeyDown = Input.GetKey(KeyCode.W);
        var backwardKeyDown = Input.GetKey(KeyCode.S);
        var rightKeyDown = Input.GetKey(KeyCode.D);
        var leftKeyDown = Input.GetKey(KeyCode.A);

        if (forwardKeyDown)
        {
            _prevKeyDown = true;

            if (rightKeyDown)
            {
                MoveForwardRight();
                return;
            }

            if (leftKeyDown)
            {
                MoveForwardLeft();
                return;
            }

            MoveForward();
            return;
        }

        if (backwardKeyDown)
        {
            _prevKeyDown = true;

            if (rightKeyDown)
            {
                MoveBackwardRight();
                return;
            }

            if (leftKeyDown)
            {
                MoveBackwardLeft();
                return;
            }

            MoveBackward();
            return;
        }

        if (rightKeyDown)
        {
            _prevKeyDown = true;
            MoveRight();
            return;
        }

        if (leftKeyDown)
        {
            _prevKeyDown = true;
            MoveLeft();
            return;
        }


        if (_prevKeyDown)
        {
            OnStopMoving(_prevDirection);
            _prevKeyDown = false;
        }

    }

    void MoveForward()
    {
        var pos = _transform.position;
        pos.y += _crossSpeed;
        _transform.position = pos;
        _prevDirection = Direction.Forward;
        OnMove(Direction.Forward);

    }
    void MoveBackward()
    {
        var pos = _transform.position;
        pos.y -= _crossSpeed;
        _transform.position = pos;
        _prevDirection = Direction.Backward;
        OnMove(Direction.Backward);
    }
    void MoveRight()
    {
        var pos = _transform.position;
        pos.x += _crossSpeed;
        _transform.position = pos;
        _prevDirection = Direction.Right;
        OnMove(Direction.Right);
    }
    void MoveLeft()
    {
        var pos = _transform.position;
        pos.x -= _crossSpeed;
        _transform.position = pos;
        _prevDirection = Direction.Left;
        OnMove(Direction.Left);
    }

    void MoveForwardRight()
    {
        var pos = _transform.position;
        pos.y += _diagonalSpeed;
        pos.x += _diagonalSpeed;
        _transform.position = pos;
        _prevDirection = Direction.ForwardRight;
        OnMove(Direction.ForwardRight);
    }

    void MoveForwardLeft()
    {
        var pos = _transform.position;
        pos.y += _diagonalSpeed;
        pos.x -= _diagonalSpeed;
        _transform.position = pos;
        _prevDirection = Direction.ForwardLeft;
        OnMove(Direction.ForwardLeft);
    }

    void MoveBackwardRight()
    {
        var pos = _transform.position;
        pos.y -= _diagonalSpeed;
        pos.x += _diagonalSpeed;
        _transform.position = pos;
        _prevDirection = Direction.BackwardRight;
        OnMove(Direction.BackwardRight);
    }

    void MoveBackwardLeft()
    {
        var pos = _transform.position;
        pos.y -= _diagonalSpeed;
        pos.x -= _diagonalSpeed;
        _transform.position = pos;
        _prevDirection = Direction.BackwardLeft;
        OnMove(Direction.BackwardLeft);
    }

    public enum Direction
    {
        Forward,
        Backward,
        Right,
        Left,
        ForwardRight,
        ForwardLeft,
        BackwardRight,
        BackwardLeft,
    }

}

