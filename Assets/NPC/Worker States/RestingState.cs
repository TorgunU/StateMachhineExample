using UnityEngine;

namespace Assets.NPC.WorkerStates
{
    public class RestingState : IMobState
    {
        private ITimer _timer;

        private readonly WorkingStateConfig _config;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly WorkerStateMachineData _data;

        public RestingState(WorkingStateConfig config, IStateSwitcher stateSwitcher,
            WorkerStateMachineData machineData, ITimer timer)
        {
            _config = config;
            _stateSwitcher = stateSwitcher;
            _data = machineData;
            _timer = timer;
        }

        public void Enter()
        {
            _timer.RequiredTime = _config.Duration;
            _timer.StartCalculate();

            Debug.Log(GetType());
        }

        public void Exit()
        {
            _timer.StopCalculate();

            // need to fix
            //_data.TargetPoint = _config.TargetPoint;
        }

        public void Update()
        {
            if (_timer.IsReached() == false)
                return;

            _stateSwitcher.SwitchState<MovingToWorkState>();
        }
    }
}