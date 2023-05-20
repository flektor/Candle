using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Transform _transform;


    Direction _direction;
    float _speed = .05f;

   public enum Direction
    {
        Forward,
        Backward,
        Right,
        Left
    }

    public delegate void OnChangeDirection(Direction direction);


   public  OnChangeDirection OnChangeDirectionCallback;

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _direction = Direction.Forward;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         
        var forwardKeyDown = Input.GetKey(KeyCode.W);
        var backwardKeyDown = Input.GetKey(KeyCode.S);
        var rightKeyDown = Input.GetKey(KeyCode.D);
        var leftKeyDown = Input.GetKey(KeyCode.A);

        if (forwardKeyDown)
        {
            MoveForward();
        }

        if (backwardKeyDown)
        {
            MoveBackward();
        }

        if (rightKeyDown)
        {
            MoveRight();
        }

        if (leftKeyDown)
        {
            MoveLeft();
        }

    }
     
    void MoveForward()
    {
       var pos =  _transform.position;
       pos.y += _speed;
       _transform.position = pos;
       SetDirection(Direction.Forward);
    }
    void MoveBackward()
    {
        var pos = _transform.position;
        pos.y -= _speed;
        _transform.position = pos;
        SetDirection(Direction.Backward);
    }
    void MoveRight()
    {
        var pos = _transform.position;
        pos.x += _speed;
        _transform.position = pos;
        SetDirection(Direction.Right);
    }
    void MoveLeft()
    {
        var pos = _transform.position;
        pos.x -= _speed;
        _transform.position = pos;
       SetDirection(Direction.Left);
    }

    void SetDirection(Direction direction)
    {
        if (_direction != direction)
        {
            _direction = direction;
            OnChangeDirectionCallback(direction);
        }
    }

}
