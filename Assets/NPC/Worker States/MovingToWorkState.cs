using Assets.NPC;
using Assets.NPC.WorkerStates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingToWorkState : MovingToTargetState
{
    public MovingToWorkState(MovingToTargetStateConfig config, WorkerStateMachineData data, 
        Transform workerTranform, Assets.NPC.IStateSwitcher switcher) 
        : base(config, data, workerTranform, switcher)
    {
    }

    protected override void SwitchState()
    {
        Switcher.SwitchState<WorkingState>();
    }
}
