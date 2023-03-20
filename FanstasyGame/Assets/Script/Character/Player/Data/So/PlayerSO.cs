using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Custom/Characters/Player")]
public class PlayerSO : ScriptableObject
{
    [field: SerializeField]public PlayerGrounedData GrounedData
    {
        get; private set;
    }
    [field: SerializeField]public PlayerAirBroneData AirBroneData
    {
        get; private set;
    }
}
