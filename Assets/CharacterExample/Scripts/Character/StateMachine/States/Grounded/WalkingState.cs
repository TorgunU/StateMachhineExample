using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : GroundedState
{
    private readonly WalkingStateConfig _config;

    public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
        : base(stateSwitcher, data, character)
    {
        _config = character.Config.WalkingStateConfig;
    }

    public override void Enter()
    {
        base.Enter();

        View.StartRunning();

        Data.Speed = _config.Speed;
    }

    public override void Exit()
    {
        base.Exit();

        View.StopRunning();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
        {
            StateSwitcher.SwitchState<IdlingState>();
        }
        else if(Input.Movement.Walk.IsPressed() == false)
        {
            StateSwitcher.SwitchState<RunningState>();
        }
    }
}
