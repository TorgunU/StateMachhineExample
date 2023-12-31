using System.Collections.Generic;
using System.Linq;
using Assets.NPC.WorkerStates;
using TMPro;
using UnityEngine;

namespace Assets.NPC
{
    public class WorkerStateMachine : IStateSwitcher
    {
        private List<IMobState> _states;
        private IMobState _currentState;

        private readonly WorkerStateMachineData Data;
        private readonly WorkerConfig _config;

        public WorkerStateMachine(WorkerConfig workerConfig, Transform workerTranform,
            ITimer mobStateTimer)
        {
            _config = workerConfig;
            Data = new WorkerStateMachineData();

            _states = new List<IMobState>()
            {
                new RestingState(_config.WorkingStateConfig, this, Data, mobStateTimer),
                new MovingToRestState(_config.WorkingStateConfig, Data, workerTranform, this),
                new WorkingState(_config.WorkingStateConfig, this, Data, mobStateTimer),
                new MovingToWorkState(_config.WorkingStateConfig, Data, workerTranform, this)
            };

            _currentState = _states[0];
            _currentState.Enter();
        }

        public void SwitchState<T>() where T : IMobState
        {
            IMobState state = _states.FirstOrDefault(state => state is T);

            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        public void Update() => _currentState.Update();
    }
}