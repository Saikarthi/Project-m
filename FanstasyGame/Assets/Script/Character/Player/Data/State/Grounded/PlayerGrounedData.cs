using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerGrounedData
{
    [field: SerializeField][field: Range(0, 25f)] public float BaseSpeed { get; private set; } = 5f;
    [field: SerializeField] public PlayerRotationData BaseRotationData { get; private set; }
    [field: SerializeField] public PlayerWalkData BaseWalkData { get; private set; } 
    [field: SerializeField] public PlayerSprintingData BaseSprintingData { get; private set; } 
    [field: SerializeField] public PlayerStopingData StopingData { get; private set; } 

}
