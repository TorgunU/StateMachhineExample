using System;
using UnityEngine;

namespace Assets.NPC
{
    [Serializable]
    public abstract class MovingToTargetStateConfig
    {
        [SerializeField] private float _speed;

        public float Speed => _speed;
    }
}