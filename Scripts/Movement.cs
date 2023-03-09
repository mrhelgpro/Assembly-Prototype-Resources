using UnityEngine;
using AssemblyActorCore;

public class Movement : Action
{
    public float Speed = 1;
    public float Shift = 3;

    private Movable _movable;
    private Animatorable _animatorable;
    //private Positionable _positionable;

    public override void Initialization()
    {
        _movable = gameObject.GetModel<Movable>();
        _animatorable = gameObject.GetModel<Animatorable>();
    }

    public override void CheckLoop()
    {
        Activate();
    }

    public override void UpdateLoop()
    {

    }

    public override void FixedLoop()
    {
        float speed = Speed * (Input.A == Inputable.Key.Press ? Shift : 1);

        Vector3 velocity = Input.Direction * speed;

        _animatorable.SetAnimation(Name, velocity.magnitude);  
        //_movable.MoveByVelocity(Input.Direction, speed);
        //_movable.MoveToPosition(Input.Direction, speed);

        if (Input.A == Inputable.Key.Press)
        {
            _movable.MoveToPosition(Input.Direction, Shift);
        }
        else
        {
            _movable.MoveByVelocity(Input.Direction, Speed);
        }
    }
}