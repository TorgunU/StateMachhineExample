using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.NPC
{
    [Serializable]
    public class WorkingStateConfig : MovingToTargetStateConfig
    {
        [SerializeField] private float _duration;
        // some other fields

        public float Duration { get => _duration; }
    }
}