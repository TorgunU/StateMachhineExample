using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerStateMachineData
{
    public Transform TargetPoint { get; set; }
    public IMobState PreviousState { get; set; }
}
