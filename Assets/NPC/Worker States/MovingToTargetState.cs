using System;
using UnityEngine;

namespace Assets.NPC.WorkerStates
{
    public abstract class MovingToTargetState : IMobState
    {
        protected IStateSwitcher Switcher;
        protected MovingToTargetStateConfig _config;

        protected readonly WorkerStateMachineData _data;
        protected readonly Transform WorkerTranform;

        private readonly float _epsilon = 0.01f;

        public MovingToTargetState(MovingToTargetStateConfig config, WorkerStateMachineData data,
            Transform workerTranform, IStateSwitcher switcher)
        {
            _config = config;
            WorkerTranform = workerTranform;
            _data = data;
            Switcher = switcher;
        }

        public virtual void Enter()
        {
            Debug.Log(GetType());
        }

        public virtual void Exit()
        {
            _data.TargetPoint = null;
        }

        public virtual void Update()
        {
            if(IsMovedToTarget())
            {
                MoveToTarget();
            }

            SwitchState();
        }

        protected virtual bool IsMovedToTarget()
        {
            return Vector3.Distance(WorkerTranform.position, _data.TargetPoint.position) <= _epsilon;
        }

        protected virtual void MoveToTarget()
        {
            Vector3 direction = (_data.TargetPoint.position - WorkerTranform.position).normalized;
            WorkerTranform.position += _config.Speed * Time.deltaTime * direction;
        }

        protected abstract void SwitchState();
    }
}