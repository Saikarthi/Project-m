using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerJumpData 
{
    [field: SerializeField] public PlayerRotationData RotationData { get; private set; }
    [field: SerializeField] public float JumpUpDecelerate { get; private set; }

    [field: SerializeField] public Vector3 StationaryForce { get; private set; }
    [field: SerializeField] public Vector3 MediumForce { get; private set; }
    [field: SerializeField] public Vector3 StrongForce { get; private set; }
}
