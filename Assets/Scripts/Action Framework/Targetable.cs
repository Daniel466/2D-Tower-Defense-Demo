using System;
using UnityEngine;
using System.Collections.Generic;

public class Targetable : MonoBehaviour
{
    [SerializeField] private List<TargetType> types = new List<TargetType>();

    public event Action TargetableStatusRemoved;

    public void Disable()
    {
        SafeEventHandler.SafelyBroadcastAction(ref TargetableStatusRemoved);
        enabled = false;
    }
}