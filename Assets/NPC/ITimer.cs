using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimer 
{
    public float RequiredTime { get; set; }
    public float CurrentTime { get; set; }

    bool IsReached();
    void StartCalculate();
    void StopCalculate();
}
