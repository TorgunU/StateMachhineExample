using System;
using UnityEngine;

[Serializable]
public class SprintStateConfig
{
    [SerializeField, Range(11, 20)] private float _speed;

    public float Speed => _speed;
}
