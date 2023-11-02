using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class SprintState : GroundedState
{
    private readonly SprintStateConfig _config;

    public SprintState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) 
        : base(stateSwitcher, data, character)
    {
        _config = character.Config.SprintStateConfig;
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
        
        if (Input.Movement.Sprint.IsPressed() == false)
        {
            StateSwitcher.SwitchState<RunningState>();
        }
    }
}
