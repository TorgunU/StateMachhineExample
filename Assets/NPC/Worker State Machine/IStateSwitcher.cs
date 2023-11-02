using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.NPC
{
    public interface IStateSwitcher 
    {
        void SwitchState<T>() where T : IMobState;
    }
}