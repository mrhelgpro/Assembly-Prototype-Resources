using UnityEngine;
using AssemblyActorCore;

public class Movement : Action
{
    public float Speed = 1;
    public float Shift = 3;

    private Movable _movable;
    private Animatorable _animatorable;
    //private Positionable _positionable;

    private Rigidbody _rigidbody;

    protected override void Initialization()
    {
        _movable = gameObject.GetActorModel<Movable>();
        _animatorable = gameObject.GetActorModel<Animatorable>();
        _rigidbody = gameObject.GetRigidbidyComponent();
    }

    public override void WaitLoop()
    {
        actionable.Activate(gameObject, Type);
    }

    public override void Enter()
    {
        _rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        _rigidbody.freezeRotation = true;
        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = false;
    }

    public override void UpdateLoop()
    {

    }

    public override void FixedLoop()
    {
        float speed = input.A == Inputable.Key.Press ? Shift : Speed;

        float velocity = (input.Direction * speed).magnitude;

        _animatorable.SetAnimation(Name, velocity);  

        if (input.A == Inputable.Key.Press)
        {
            moveToDirection(input.Direction, speed);
        }
        else
        {
            moveToDirection(input.Direction, speed);
        }
    }

    public override void Exit()
    {
        _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        _rigidbody.velocity = Vector3.zero;
    }

    private void moveToDirection(Vector3 direction, float speed)
    {
        direction.Normalize();

        if (direction == Vector3.zero && _movable.Gravity == 0)
        {
            _rigidbody.velocity = Vector3.zero;
        }
        else
        {
            _rigidbody.MovePosition(_rigidbody.position + direction * speed * _movable.GetSpeedScale);
            _rigidbody.AddForce(Physics.gravity * _movable.Gravity, ForceMode.Acceleration);
        }
    }
}

/*
public void MoveToPosition(Vector3 direction, float speed)
{
    direction.Normalize();

    _rigidbody.constraints = RigidbodyConstraints.FreezeAll;

    _mainTransform.position += direction * speed * Time.fixedDeltaTime;

    float speedCal = ((_mainTransform.position - prePos) / Time.deltaTime).magnitude;
    Debug.Log("SPEED " + speedCal);
    prePos = _mainTransform.position;
}

private void MoveForPlatformer(Vector2 direction, float speed)
{
    direction.Normalize();

    _rigidbody2D.constraints = RigidbodyConstraints2D.None;
    _rigidbody2D.freezeRotation = true;

    _rigidbody2D.gravityScale = Gravity;

    float acceleration2D = 50;

    float horizontal = direction.x * speed * _speedScale * acceleration2D;
    float vertical = _rigidbody2D.velocity.y;

    _rigidbody2D.velocity = new Vector2(horizontal, vertical);
}
*/