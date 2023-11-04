using Assets.NPC;
using Assets.NPC.WorkerStates;
using UnityEditor.Recorder.AOV;
using UnityEngine;

public class MovingToRestState : MovingToTargetState
{
    public MovingToRestState(MovingToTargetStateConfig config, WorkerStateMachineData data, 
        Transform workerTranform, Assets.NPC.IStateSwitcher switcher) 
        : base(config, data, workerTranform, switcher)
    {

    }

    protected override void SwitchState()
    {
        Switcher.SwitchState<RestingState>();
    }
}
