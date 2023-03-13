using UnityEngine;
using AssemblyActorCore;

public class MovementController : ActionBehaviour
{
    public float Speed = 3;

    protected override void Initialization() { }

    public override void WaitLoop()
    {
        actionable.Activate(gameObject, Type);
    }

    public override void Enter() => movable.FreezRotation();

    public override void UpdateLoop()
    {

    }

    public override void FixedLoop()
    {
        float speed = inputable.A == Inputable.Key.Press ? Speed * 2 : Speed;

        animatorable.SetAnimation(Name, (inputable.Direction * speed).magnitude);

        if (inputable.A == Inputable.Key.Press)
        {
            movable.MoveToPosition(inputable.Direction, speed);
        }
        else
        {
            movable.MoveToDirection(inputable.Direction, speed);
        }
    }

    public override void Exit() => movable.FreezAll();
}