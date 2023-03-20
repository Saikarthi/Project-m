using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAirBroneData
{
    [field: SerializeField] public PlayerJumpData JumpData { get; private set; }
}
