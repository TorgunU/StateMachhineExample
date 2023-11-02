using System;
using UnityEngine;

namespace Assets.NPC
{
    [Serializable]
    public class RestStateConfig : MovingToTargetStateConfig
    {
        [SerializeField] private float _duration;
        // some other fields

        public float Duration { get => _duration; }
    }
}