using UnityEngine;

namespace Assets.NPC.WorkerStates
{
    public abstract class MovingToTargetState : IMobState
    {
        protected WorkerStateMachineData Data;

        private Transform _workerTranform;
        private MovingToTargetStateConfig _config;

        private readonly float _epsilon = 0.01f;

        public MovingToTargetState(MovingToTargetStateConfig config, WorkerStateMachineData data,
            Transform workerTranform)
        {
            _config = config;
            _workerTranform = workerTranform;
            Data = data;
        }

        public virtual void Enter()
        {
            Debug.Log(GetType());
        }

        public virtual void Exit()
        {
            Data.TargetPoint = null;
        }

        public virtual void Update()
        {
            MoveToTarget();
        }

        protected bool IsMovedToTarget()
        {
            return Vector3.Distance(_workerTranform.position, Data.TargetPoint.position) <= _epsilon;
        }

        private void MoveToTarget()
        {
            Vector3 direction = (Data.TargetPoint.position - _workerTranform.position).normalized;
            _workerTranform.position += _config.Speed * Time.deltaTime * direction;
        }
    }
}