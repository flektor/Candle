using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Transform _transform;

    float _speed = .05f;

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();

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
    }
    void MoveBackward()
    {
        var pos = _transform.position;
        pos.y -= _speed;
        _transform.position = pos;
    }
    void MoveRight()
    {
        var pos = _transform.position;
        pos.x += _speed;
        _transform.position = pos;
    }
    void MoveLeft()
    {
        var pos = _transform.position;
        pos.x -= _speed;
        _transform.position = pos;
    }



}
