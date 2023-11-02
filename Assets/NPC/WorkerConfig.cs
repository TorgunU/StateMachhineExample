using UnityEngine;

namespace Assets.NPC
{
    [CreateAssetMenu(fileName = "WorkerConfig", menuName = "Configs/WorkerConfig")]
    public class WorkerConfig : ScriptableObject
    {
        [SerializeField] private RestStateConfig _restStateConfig;
        [SerializeField] private MovingToTargetStateConfig _movingStateConfig;
        [SerializeField] private WorkingStateConfig _workingStateConfig;

        public RestStateConfig RestStateConfig => _restStateConfig;
        public MovingToTargetStateConfig MovingToTargetStateConfig => _movingStateConfig;
        public WorkingStateConfig WorkingStateConfig => _workingStateConfig;
    }
}
