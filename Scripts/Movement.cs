using UnityEngine;
using AssemblyActorCore;

public class Movement : Action
{
    public Movable.Constraints Constraints = Movable.Constraints.None;
    public float Speed = 1;
    public float Shift = 3;

    private Movable _movable;
    private Animatorable _animatorable;
    //private Positionable _positionable;

    protected override void Initialization()
    {
        _movable = gameObject.GetActorComponent<Movable>();
        _animatorable = gameObject.GetActorComponent<Animatorable>();
    }

    public override void WaitLoop()
    {
        actionable.Activate(gameObject, Type);
    }

    public override void Enter()
    {
        _movable.SetConstraints(Constraints);
    }

    public override void UpdateLoop()
    {

    }

    public override void FixedLoop()
    {
        float speed = input.A == Inputable.Key.Press ? Shift : Speed;
        float velocity = (input.Direction * speed).magnitude;

        _animatorable.SetAnimation(Name, velocity);
        _movable.MoveToDirection(input.Direction, speed);
    }

    public override void Exit()
    {
        _movable.SetConstraints(Movable.Constraints.FreezAll);
    }
}