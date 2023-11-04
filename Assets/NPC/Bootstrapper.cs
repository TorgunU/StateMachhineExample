using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Assets.NPC
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Transform _idlePoint;
        [SerializeField] private Transform _workPoint;
        [SerializeField] private WorkerConfig _workerConfig;
        [SerializeField] private Worker _worker;
        [SerializeField] private MobStateTimer _mobStateTimer;

        private void Awake()
        {
            CreateWorkerConfig();
            InitWorker();
        }

        private void CreateWorkerConfig()
        {
            // need to Fix
            //_workerConfig.RestStateConfig.TargetPoint = _idlePoint;
            //_workerConfig.WorkingStateConfig.TargetPoint = _workPoint;
        }

        private void InitWorker()
        {
            WorkerStateMachine stateMachine = new WorkerStateMachine(_workerConfig, _worker.transform,
                _mobStateTimer);
            _worker.Init(stateMachine);
        }
    }
}
