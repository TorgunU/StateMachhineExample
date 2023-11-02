using System;
using UnityEngine;

[Serializable]
public class WalkingStateConfig
{
    [SerializeField, Range(1, 9)] private float _speed;

    public float Speed => _speed;
}
