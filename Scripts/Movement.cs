using UnityEngine;
using AssemblyActorCore;

public class Movement : Action
{
    public float Speed = 1;
    public float Shift = 3;

    private Movable _movable;
    private Animatorable _animatorable;
    //private Positionable _positionable;

    protected override void Initialization()
    {
        _movable = gameObject.GetModel<Movable>();
        _animatorable = gameObject.GetModel<Animatorable>();
    }

    public override void CheckLoop()
    {
        Activate();
    }

    public override void Enter()
    {
        _movable.Gravity = 2;
    }

    public override void UpdateLoop()
    {

    }

    public override void FixedLoop()
    {
        float speed = Input.A == Inputable.Key.Press ? Shift : Speed;

        float velocity = (Input.Direction * speed).magnitude;

        _animatorable.SetAnimation(Name, velocity);  

        if (Input.A == Inputable.Key.Press)
        {
            _movable.MoveToPosition(Input.Direction, speed);
        }
        else
        {
            _movable.MoveToDirection(Input.Direction, speed);
        }
    }

    public override void Exit()
    {

    }
}