using UnityEngine;

namespace Assets.NPC
{
    public class Worker : MonoBehaviour
    {
        private WorkerStateMachine _stateMachine;

        public void Init(WorkerStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void Update()
        {
            _stateMachine.Update();
        }
    }
}