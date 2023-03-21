using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStopingData 
{
    [field: SerializeField][field: Range(0, 500f)] public float MediumForce { get; private set; } = 6.5f;
    [field: SerializeField][field: Range(0, 500f)] public float HardForce { get; private set; } = 8f;

}
