using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public struct AiConfig
{
    public float Speed;
    public float MinDistanceToTarget;
    public Transform[] Waypoints;
}
