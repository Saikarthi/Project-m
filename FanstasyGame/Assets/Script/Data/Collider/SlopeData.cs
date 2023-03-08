using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlopeData 
{
    [field: SerializeField] [field:Range(0,1f)] public float stepHeightPercentage { get; private set; } = 0.25f;
    [field: SerializeField] [field:Range(0,5f)] public float floatRayDistance { get; private set; } = 2f;
    [field: SerializeField][field: Range(0, 50f)] public float stepReachForce { get; private set; } = 25f;

}
