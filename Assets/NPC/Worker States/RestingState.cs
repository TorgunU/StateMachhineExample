using UnityEngine;

namespace Assets.NPC.WorkerStates
{
    public class RestingState : MovingToTargetState
    {
        private RestStateConfig _config;
        private IStateSwitcher _stateSwitcher;
        private float _passedTime;

        public RestingState(RestStateConfig config, IStateSwitcher stateSwitcher, WorkerStateMachineData machineData,
            Transform workerTranform) : base(config, machineData, workerTranform)
        {
            _config = config;
            _stateSwitcher = stateSwitcher;
        }

        public override void Enter()
        {
            base.Enter();
            Data.Duration = _config.Duration;
            Data.TargetPoint = _config.TargetPoint;

            Debug.Log(GetType());
        }

        public override void Exit()
        {
            base.Exit();
            _passedTime = 0;
            Data.TargetPoint = null;
        }

        public override void Update()
        {
            base.Update();

            _passedTime += Time.deltaTime;

            if (IsTimePassed() == false)
            {
                return;
            }

            if (IsMovedToTarget())
            {
                _stateSwitcher.SwitchState<WorkingState>();
            }
        }

        private bool IsTimePassed()
        {
            return _passedTime >= _config.Duration;
        }
    }
}